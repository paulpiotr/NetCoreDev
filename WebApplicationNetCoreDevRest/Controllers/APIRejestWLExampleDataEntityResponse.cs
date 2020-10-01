using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationNetCoreDevRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIRejestWLExampleDataEntityResponse : ControllerBase
    {


        /// <summary>
        /// readFileAsUTF8(string fileName)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string readFileAsUTF8(string fileName, int? getEncoding = null)
        {
            try
            {
                Encoding encoding = Encoding.Default;
                string streamReaderReadToEnd = string.Empty;
                using (StreamReader streamReader = new StreamReader(fileName, Encoding.Default))
                {
                    streamReaderReadToEnd = streamReader.ReadToEnd();
                    encoding = streamReader.CurrentEncoding;
                    streamReader.Close();
                }
                if (encoding == Encoding.UTF8)
                {
                    return streamReaderReadToEnd;
                }
                byte[] encodingGetBytes = encoding.GetBytes(streamReaderReadToEnd);
                byte[] encodingConvertUTF8 = Encoding.Convert(encoding, Encoding.UTF8, encodingGetBytes);
                return Encoding.UTF8.GetString(encodingConvertUTF8);
            }
            catch
            {
                return null;
            }
        }

        // GET: api/<APIRejestWLExampleDataEntityResponse>
        [HttpGet]
        public object Get()
        {
            string aPIRejestWLExampleDataEntityResponse = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "APIRejestWLExampleDataEntityResponse.json"), Encoding.Default);

            aPIRejestWLExampleDataEntityResponse = readFileAsUTF8(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "APIRejestWLExampleDataEntityResponse.json"));

            dynamic deserializeObject = JsonConvert.DeserializeObject(aPIRejestWLExampleDataEntityResponse);
            return Ok(deserializeObject);
        }
    }
}
