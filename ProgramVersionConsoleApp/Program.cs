#region using

using System;
using System.Globalization;
using System.IO;
using System.Xml;
using NetAppCommon.Helpers.Object;

#endregion

namespace ProgramVersionConsoleApp
{
    internal class Program
    {
        private const string Property = "Property";
        private const string Value = "Value";

        private static void Main(string[] args)
        {
            var dateTimeNowCurrent = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                0, 0, 0);
            DateTime dateTimeNow = DateTime.Now;
            var yearMonthDay = Convert.ToInt32(dateTimeNow.Year.ToString().Substring(2, 2)) + dateTimeNow.Month + dateTimeNow.Day;
            var totalMinutes = Math.Round((dateTimeNow - dateTimeNowCurrent).TotalMinutes, 0);
            var version = $"5.{yearMonthDay}.{totalMinutes}";
            var assemblyVersion = version;
            var fileVersion = version;
            //var unixTimeSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            //$"5.{unixTimeSeconds.ToString().Substring(0, 2)}.{unixTimeSeconds.ToString().Substring(2, 4)}.{unixTimeSeconds.ToString().Substring(6, 4)}";
            Guid versionGuid = ObjectHelper.GuidFromString(fileVersion);
            Console.WriteLine($"Version: {version} ");
            Console.WriteLine($"Assembly Version: {assemblyVersion} ");
            Console.WriteLine($"File Version: {fileVersion} ");
            Console.WriteLine($"Assembly Version Guid: {versionGuid} ");
            foreach (var path in args)
            {
                Guid upgradeVersionGuid = ObjectHelper.GuidFromString(Path.GetFileName(path));
                setCsproj(path, version, assemblyVersion, fileVersion);
                setAip(path, versionGuid.ToString(), version, upgradeVersionGuid.ToString());
            }
        }

        private static void setCsproj(string csprojPath, string version, string assemblyVersion, string fileVersion)
        {
            try
            {
                if (File.Exists(csprojPath) && Path.GetExtension(csprojPath).ToLower().Contains("csproj"))
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(csprojPath);
                    XmlNode root = xmlDocument.DocumentElement;
                    if (root != null)
                    {
                        XmlNode xmlNodeVersion = root.SelectSingleNode("descendant::PropertyGroup/Version");
                        if (null != xmlNodeVersion)
                        {
                            xmlNodeVersion.InnerText = version;
                        }

                        xmlNodeVersion = root.SelectSingleNode("descendant::PropertyGroup/AssemblyVersion");
                        if (null != xmlNodeVersion)
                        {
                            xmlNodeVersion.InnerText = assemblyVersion;
                        }

                        xmlNodeVersion = root.SelectSingleNode("descendant::PropertyGroup/FileVersion");
                        if (null != xmlNodeVersion)
                        {
                            xmlNodeVersion.InnerText = fileVersion;
                        }

                        xmlDocument.Save(csprojPath);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void setAip(string aipPath, string versionGuid, string version, string upgradeVersionGuid)
        {
            try
            {
                if (File.Exists(aipPath) && Path.GetExtension(aipPath).ToLower().Contains("aip"))
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(aipPath);
                    if (true)
                    {
                        foreach (XmlElement xmlElementRow in xmlDocument.GetElementsByTagName("DOCUMENT")?.Item(0)
                            ?.ChildNodes?.Item(0)!)
                        {
                            var value = string.Empty;
                            if (xmlElementRow.HasAttribute(Property) && xmlElementRow.HasAttribute(Value))
                            {
                                switch (xmlElementRow.Attributes[Property].Value)
                                {
                                    case "ProductCode":
                                        value = "1045:{" + versionGuid.ToUpper() + "}";
                                        Console.WriteLine(
                                            $"Change property {xmlElementRow.Attributes[Property].Value} value {xmlElementRow.Attributes[Value].Value} to {value}");
                                        xmlElementRow.Attributes["Value"].Value = value;
                                        break;
                                    case "UpgradeCode":
                                            value = "{" + upgradeVersionGuid.ToUpper() + "}";
                                            Console.WriteLine(
                                                $"Change property {xmlElementRow.Attributes[Property].Value} value {xmlElementRow.Attributes[Value].Value} to {value}");
                                            xmlElementRow.Attributes["Value"].Value = value;
                                            break;
                                    case "ProductVersion":
                                        value = version;
                                        Console.WriteLine(
                                            $"Change property {xmlElementRow.Attributes[Property].Value} value {xmlElementRow.Attributes[Value].Value} to {value}");
                                        xmlElementRow.Attributes["Value"].Value = value;
                                        break;
                                }
                            }
                        }

                        xmlDocument.Save(aipPath);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
