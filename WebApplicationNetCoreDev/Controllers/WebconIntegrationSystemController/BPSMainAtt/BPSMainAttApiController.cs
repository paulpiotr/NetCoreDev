using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WebconIntegrationSystem.Data.BPSMainAttDbContext;
using WebconIntegrationSystem.Models.BPSMainAtt;
using WebconIntegrationSystem.Repositories.BPSMainAtt;

namespace WebApplicationNetCoreDev.Controllers.WebconIntegrationSystemController.BPSMainAtt
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class BPSMainAttApiController : ControllerBase
    {
        #region private readonly log4net.ILog _log4net
        /// <summary>
        /// log4net
        /// </summary>
        private readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        private readonly BPSMainAttDbContext _bPSMainAttDbContext;

        public BPSMainAttApiController(BPSMainAttDbContext bPSMainAttDbContext)
        {
            _bPSMainAttDbContext = bPSMainAttDbContext;
        }

        #region public async Task<ActionResult<object>> GetAsync(int atfId)
        /// <summary>
        /// example: /api/BPSMainAttApi/XMLPZCObject/1/WartoscTowaru.SzczegolyWartosci
        /// </summary>
        /// <param name="atfId"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("XMLPZCObject/{atfId}/{tagName?}")]
        public async Task<ActionResult<object>> GetXMLPZCObjectAsync(int atfId, string tagName = null)
        {
            try
            {
                WfattachmentFiles wfattachmentFiles = await WfattachmentFilesRepository.GetInstance(_bPSMainAttDbContext).FindByAtfIdAsync(atfId);
                if (null != wfattachmentFiles)
                {
                    var xmlDocument = new XmlDocument();
                    using (var memoryStream = new MemoryStream(wfattachmentFiles.AtfValue))
                    {
                        xmlDocument.Load(memoryStream);
                    }
                    using (var stringWriter = new StringWriter())
                    {
                        using (var xmlWriter = XmlWriter.Create(stringWriter))
                        {
                            XmlNodeList xmlNodeList = null;
                            xmlDocument.WriteTo(xmlWriter);
                            xmlWriter.Flush();
                            var pattern = @"ns[0-9]+\:";
                            var stringReplace = Regex.Replace(stringWriter.GetStringBuilder().ToString(), pattern, string.Empty);
                            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(stringReplace)))
                            {
                                xmlDocument.Load(memoryStream);
                            }
                            if (null != tagName && !string.IsNullOrWhiteSpace(tagName))
                            {
                                char[] delimiterChars = { '.' };
                                var listOfAttributes = new List<string>(tagName.Split(delimiterChars)).Select(x => x.Trim()).ToList();
                                if (null != listOfAttributes)
                                {
                                    listOfAttributes.ForEach(tagName =>
                                    {
                                        xmlNodeList = xmlDocument.GetElementsByTagName(tagName);
                                    });
                                }
                            }
                            return null != tagName && !string.IsNullOrWhiteSpace(tagName) ? xmlNodeList : xmlDocument;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }
            return NotFound();
        }
        #endregion
    }
}
