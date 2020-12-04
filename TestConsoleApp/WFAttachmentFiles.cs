using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;
using WebconIntegrationSystem.Repositories.BPSMainAtt;

namespace TestConsoleApp
{
    public class WFAttachmentFiles
    {
        public static async System.Threading.Tasks.Task AttachWFAttachmentFilesAsync()
        {
            string filePath = @"d:\wpisy.xlsx";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    WfattachmentFilesRepository wfattachmentFilesRepository = WfattachmentFilesRepository.GetInstance();
                    do
                    {
                        while (reader.Read())
                        {
                            object atfId = reader.GetValue(0);
                            object atfOrginalName = reader.GetValue(16);
                            try
                            {
                                atfId = Convert.ToInt32(atfId);
                                if ((int)atfId > 0)
                                {
                                    Console.WriteLine(atfId);
                                    Console.WriteLine(atfOrginalName);
                                    string filePathXml = Path.Combine(@"d:", Convert.ToString(atfOrginalName));
                                    Console.WriteLine(filePath);
                                    byte[] atfValue = File.ReadAllBytes(filePathXml);
                                    if (null != atfValue)
                                    {
                                        Console.WriteLine($"{ atfId }");
                                        WebconIntegrationSystem.Models.BPSMainAtt.WfattachmentFiles wfattachmentFiles = await wfattachmentFilesRepository.FindByAtfIdAsync((int)atfId);
                                        if (null != wfattachmentFiles)
                                        {
                                            wfattachmentFiles.AtfValue = atfValue;
                                            wfattachmentFiles = await wfattachmentFilesRepository.ModifyAsync(wfattachmentFiles);
                                            XmlDocument xmlDocument = new XmlDocument();
                                            using (MemoryStream memoryStream = new MemoryStream(wfattachmentFiles.AtfValue))
                                            {
                                                xmlDocument.Load(memoryStream);
                                            }

                                            Console.WriteLine($"{ atfId } = { wfattachmentFiles.AtfId } { JsonConvert.SerializeXmlNode(xmlDocument) }");
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error { e.Message } { e.StackTrace } { e.InnerException?.Message } { e.InnerException?.StackTrace }");
                            }
                        }
                    } while (reader.NextResult());
                }
            }
        }
    }
}
