#region using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using CommandLine;
using XsdTool.Models;

#endregion

namespace XsdTool
{
    public class Program
    {
        public static void Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts => RunOptionsAndReturnExitCode(opts))
                .WithNotParsed(HandleParseError);

        public static int RunOptionsAndReturnExitCode(Options options, string filePath = null)
        {
            try
            {
                var @namespace = options.Namespace;
                filePath ??= options.FilePath;
                var className = !string.IsNullOrEmpty(options.ClassName)
                    ? options.ClassName
                    : GetClassNameFromFileName(filePath);
                var output = options.Output;
                var root = options.Root;
                var filePathOutput = Path.Combine(output, $"{className}.cs");
                if (File.Exists(filePath))
                {
                    List<XsdModel> xsdModelList = XmlSchemaTraverse(filePath, root);
                    var xsd = new Xsd {Session = new Dictionary<string, object>()};
                    xsd.Session.Add("_Namespace_", @namespace);
                    xsd.Session.Add("_ClassName_", className);
                    xsd.Session.Add("_DatabaseSchema_", "pagard");
                    if (null != xsdModelList && xsdModelList.Count > 0)
                    {
                        xsd.Session.Add("xsdModelList", xsdModelList);
                        xsd.Initialize();
                        var xsdOutput = xsd.TransformText();
                        File.WriteAllText(filePathOutput, xsdOutput);
                    }
                }
                else if (Directory.Exists(filePath))
                {
                    Parallel.ForEach(Directory.GetFiles(filePath, "*.xsd", SearchOption.AllDirectories), file =>
                    {
                        RunOptionsAndReturnExitCode(options, file);
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
            return 0;
        }

        public static string GetClassNameFromFileName(string filePath)
        {
            try
            {
                filePath = Path.GetFileName(filePath);
                if (null != filePath && !string.IsNullOrEmpty(filePath))
                {
                    filePath = Path.GetFileName(filePath).Replace(Path.GetExtension(filePath), string.Empty);
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        var className = string.Join("_",
                            Regex.Split(filePath,
                                @"(?<!^)(?=[A-Z])"));
                        char[] delimiterChars = {' ', ',', '.', ':', '_'};
                        var words = className.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => Regex.Replace(x, @"(?<!\w)\w", m => m.Value.ToUpper())).ToList();
                        return $"{string.Join(string.Empty, words)}";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;
        }

        public static List<XsdModel> XmlSchemaTraverse(string filePath, string root = null)
        {
            var xsdModelList = new List<XsdModel>();
            string tempFileName = null;
            Console.WriteLine($"Traverse: {filePath}");
            try
            {
                if (null != root && !string.IsNullOrWhiteSpace(root))
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(filePath);
                    var xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
                    xmlNamespaceManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
                    XmlNodeList xmlNodeList =
                        xmlDocument.SelectNodes("//xs:element[starts-with(@name, '" + root + "')]",
                            xmlNamespaceManager);
                    if (xmlNodeList != null)
                    {
                        tempFileName = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".xml");
                        using StreamWriter writer = File.CreateText(tempFileName);
                        writer.WriteLine(
                            $"<xs:schema xmlns:xs='http://www.w3.org/2001/XMLSchema'>{string.Join("", xmlNodeList.Cast<XmlNode>().Select(x => x.OuterXml))}</xs:schema>");
                    }
                }

                // Add the customer schema to a new XmlSchemaSet and compile it.
                // Any schema validation warnings and errors encountered reading or
                // compiling the schema are handled by the ValidationEventHandler delegate.
                var xmlSchemaSet = new XmlSchemaSet();
                xmlSchemaSet.ValidationEventHandler += ValidationCallback;
                xmlSchemaSet.Add("http://www.w3.org/2001/XMLSchema", tempFileName ?? filePath);
                xmlSchemaSet.Compile();

                // Retrieve the compiled XmlSchema object from the XmlSchemaSet
                // by iterating over the Schemas property.
                XmlSchema xmlSchema = null;
                foreach (XmlSchema schema in xmlSchemaSet.Schemas())
                {
                    xmlSchema = schema;
                }

                // Iterate over each XmlSchemaElement in the Values collection
                // of the Elements property.
                if (xmlSchema?.Elements.Values != null)
                {
                    foreach (XmlSchemaElement element in xmlSchema?.Elements.Values)
                    {
                        // Get the complex type of the Customer element.
                        var complexType = element.ElementSchemaType as XmlSchemaComplexType;

                        // Get the sequence particle of the complex type.
                        var sequence = complexType?.ContentTypeParticle as XmlSchemaSequence;

                        // Iterate over each XmlSchemaElement in the Items collection.
                        if (sequence?.Items != null)
                        {
                            foreach (XmlSchemaObject o in sequence?.Items)
                            {
                                var xmlSchemaElement = (XmlSchemaElement)o;
                                var xmlSchemaMaxLengthFacet = 0;
                                var xmlSchemaSimpleType = xmlSchemaElement.ElementSchemaType as XmlSchemaSimpleType;
                                var xmlSchemaSimpleTypeRestriction =
                                    xmlSchemaSimpleType?.Content as XmlSchemaSimpleTypeRestriction;
                                if (xmlSchemaSimpleTypeRestriction?.Facets != null)
                                {
                                    foreach (XmlSchemaObject xmlSchemaObject in xmlSchemaSimpleTypeRestriction?.Facets)
                                    {
                                        if (xmlSchemaObject is XmlSchemaMaxLengthFacet facet)
                                        {
                                            xmlSchemaMaxLengthFacet = int.Parse(facet.Value);
                                        }
                                    }
                                }
                                //Set data type
                                string dataType;
                                switch (xmlSchemaSimpleType?.TypeCode.ToString().ToLower())
                                {
                                    case "boolean":
                                        dataType = "bool";
                                        break;
                                    default:
                                        dataType = xmlSchemaSimpleType?.TypeCode.ToString().ToLower();
                                        break;
                                }

                                //Create model
                                xsdModelList.Add(new XsdModel
                                {
                                    XmlName = xmlSchemaElement.Name,
                                    PrivateName = xmlSchemaElement.Name,
                                    PublicName = xmlSchemaElement.Name,
                                    DataType = dataType,
                                    Title = xmlSchemaElement.Name,
                                    MaxLength = xmlSchemaMaxLengthFacet
                                });
                            }
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                if (null != tempFileName && !string.IsNullOrWhiteSpace(tempFileName) && File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }

            return xsdModelList;
        }

        public static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
            Console.WriteLine(args.Exception);
        }

        public static void HandleParseError(IEnumerable<Error> errs)
        {
            RunOptionsAndReturnExitCode(new Options
            {
                Namespace = "PortalApiGus.ApiRegon.Core.Models.DaneSzukajPodmioty",
                ClassName = string.Empty,
                FilePath =
                    @"D:\Praca\NetCoreDev\PortalApiGus\ApiRegon\src\PortalApiGus.ApiRegon.Core\Models\DaneSzukajPodmioty",
                Output =
                    @"D:\Praca\NetCoreDev\PortalApiGus\ApiRegon\src\PortalApiGus.ApiRegon.Core\Models\DaneSzukajPodmioty\",
                Root = "dane"
            });
        }
    }

    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        [Option('n', "namespace", Required = true, HelpText = "Set output to [namespace] name.")]
        public string Namespace { get; set; }

        [Option('c', "classname", Required = false, HelpText = "Set output to [class] name.")]
        public string ClassName { get; set; }

        [Option('f', "filepath", Required = true, HelpText = "Set input [file path] to *.xsd file.")]
        public string FilePath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Set output to [output] to save generated [class] name.")]
        public string Output { get; set; }

        [Option('r', "root", Required = false, HelpText = "Set output to [root] Xml element.")]
        public string Root { get; set; }
    }
}
