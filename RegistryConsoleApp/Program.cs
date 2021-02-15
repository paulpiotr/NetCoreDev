#region using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

#endregion

namespace RegistryConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (null != args && args.Length > 0)
            {
                switch (args.ElementAtOrDefault(0))
                {
                    case "search":
                        SearchRegistryKey(args.ElementAtOrDefault(1), args.ElementAtOrDefault(2),
                            args.ElementAtOrDefault(3));
                        break;
                    case "delete":
                        DeleteRegistryKeys(args.ElementAtOrDefault(1));
                        break;
                }
            }
        }

        private static void SearchRegistryKey(string target, string filePath = null, string action = null)
        {
            try
            {
                try
                {
                    if (null != filePath && File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var registryKeyList = new List<RegistryKey>
                {
                    Registry.ClassesRoot,
                    Registry.CurrentUser,
                    Registry.LocalMachine,
                    Registry.CurrentConfig,
                    Registry.PerformanceData,
                    Registry.Users
                };
                var registryKeyListWithSubKeyName = new List<RegistryKey>();
                Parallel.ForEach(registryKeyList, argIterator =>
                {
                    try
                    {
                        Parallel.ForEach(argIterator.GetSubKeyNames(), argIteratorSubKeyName =>
                        {
                            try
                            {
                                RegistryKey registryKey = argIterator.OpenSubKey(argIteratorSubKeyName, false);
                                var stringBuilder = new StringBuilder();
                                if (null != registryKey)
                                {
                                    lock (registryKeyListWithSubKeyName)
                                    {
                                        registryKeyListWithSubKeyName.Add(registryKey);
                                        stringBuilder.Append(registryKey.Name);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
                if (Parallel.ForEach(registryKeyListWithSubKeyName, argIterator =>
                {
                    try
                    {
                        SearchRegistryKey(argIterator, target, true, filePath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }).IsCompleted)
                {
                    Console.WriteLine("Finish search");
                }

                switch (action)
                {
                    case "delete":
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DeleteRegistryKeys(string filePath)
        {
            try
            {
                Parallel.ForEach(File.ReadAllLines(filePath), DeleteRegistryKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DeleteRegistryKey(string key)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                key = FindParentRegistryKey(key);
                var stringList = key.Split('\\').ToList();
                var baseKey = stringList.FirstOrDefault();
                RegistryKey registryKeyBase = null;
                switch (baseKey)
                {
                    case "HKEY_CLASSES_ROOT":
                        registryKeyBase = Registry.ClassesRoot;
                        break;
                    case "HKEY_CURRENT_USER":
                        registryKeyBase = Registry.CurrentUser;
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        registryKeyBase = Registry.LocalMachine;
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        registryKeyBase = Registry.CurrentConfig;
                        break;
                    case "HKEY_PERFORMANCE_DATA":
                        registryKeyBase = Registry.PerformanceData;
                        break;
                    case "HKEY_USERS":
                        registryKeyBase = Registry.Users;
                        break;
                }

                if (null != registryKeyBase)
                {
                    stringList.RemoveAt(0);
                    key = string.Join(@"\", stringList).TrimEnd(@"\".ToCharArray());
                    RegistryKey registrySubKey = registryKeyBase.OpenSubKey(key, RegistryRights.Delete);
                    try
                    {
                        if (null != registrySubKey)
                        {
                            try
                            {
                                stringBuilder.Append($@"Try Delete Sub Key Tree: [{registryKeyBase.Name}\{key}]: ");
                                registryKeyBase.DeleteSubKeyTree(key, false);
                                registryKeyBase.DeleteSubKey(key, false);
                                stringBuilder.Append("OK");
                                stringBuilder.Append(Environment.NewLine);
                            }
                            catch (Exception e)
                            {
                                stringBuilder.Append("FAIL");
                                stringBuilder.Append(Environment.NewLine);
                                stringBuilder.Append(e.Message);
                                stringBuilder.Append(Environment.NewLine);
                                stringBuilder.Append(e.StackTrace);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        stringBuilder.Append("ERROR");
                        stringBuilder.Append(Environment.NewLine);
                        stringBuilder.Append(e.Message);
                        stringBuilder.Append(Environment.NewLine);
                        stringBuilder.Append(e.StackTrace);
                    }
                }
            }
            catch (Exception e)
            {
                stringBuilder.Append("ERROR");
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(e.Message);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(e.StackTrace);
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(stringBuilder.ToString()))
                {
                    Console.WriteLine(stringBuilder.ToString());
                }
            }
        }

        private static void AppendToFile(string text, string filePath = null)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                filePath ??= stringBuilder.Append(DateTime.Now.Year).Append(".").Append(DateTime.Now.Month)
                    .Append(".")
                    .Append(DateTime.Now.Day).Append(".").Append(DateTime.Now.Hour).Append(".").Append("txt")
                    .ToString();
                using StreamWriter streamWriter = File.AppendText(filePath);
                streamWriter.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static string FindParentRegistryKey(string key)
        {
            try
            {
                var stringBuilder = new StringBuilder();
                var stringList = key.Split('\\').ToList();
                foreach (var @string in stringList!)
                {
                    var isValidGuid = Guid.TryParse(@string, out Guid guid);
                    stringBuilder.Append(@string).Append(@"\");
                    if (isValidGuid)
                    {
                        break;
                    }
                }

                return stringBuilder.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        private static void SearchRegistryKey(RegistryKey registryKeyRoot, string target, bool quiet = true,
            string filePath = null, List<string> stringListSearchMatch = null)
        {
            var toCheck = new LinkedList<RegistryKey>();
            toCheck.AddLast(registryKeyRoot);
            while (toCheck.Count > 0)
            {
                if (toCheck.First != null)
                {
                    registryKeyRoot = toCheck.First.Value;
                }

                toCheck.RemoveFirst();
                if (registryKeyRoot != null)
                {
                    foreach (var name in registryKeyRoot.GetValueNames())
                    {
                        Exception exception = null;
                        try
                        {
                            if (registryKeyRoot.GetValueKind(name) == RegistryValueKind.String)
                            {
                                var value = (string)registryKeyRoot.GetValue(name);
                                var stringBuilder = new StringBuilder();
                                if (null != value && value.ToLower().Contains(target.ToLower()))
                                {
                                    if (null != stringListSearchMatch)
                                    {
                                        lock (stringListSearchMatch)
                                        {
                                            stringBuilder.Append(registryKeyRoot.Name).Append("\\").Append(name)
                                                .Append(Environment.NewLine).Append(value).Append(Environment.NewLine)
                                                .Append(Environment.NewLine);
                                            stringListSearchMatch.Add(stringBuilder.ToString());
                                            AppendToFile(stringBuilder.ToString(), filePath);
                                            Console.WriteLine($"Find key: [{stringBuilder}] value: [{value}]");
                                        }
                                    }
                                    else
                                    {
                                        stringBuilder.Append(registryKeyRoot.Name).Append("\\").Append(name)
                                            .Append(Environment.NewLine).Append(value).Append(Environment.NewLine)
                                            .Append(Environment.NewLine);
                                        AppendToFile(stringBuilder.ToString(), filePath);
                                        Console.WriteLine($"Find key: [{stringBuilder}] value: [{value}]");
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            exception = e;
                        }
                        finally
                        {
                            if (!quiet)
                            {
                                Console.WriteLine(null != exception
                                    ? $"{registryKeyRoot.Name} {exception.Message}"
                                    : $"{registryKeyRoot.Name} ok");
                            }
                        }
                    }

                    foreach (var sub in registryKeyRoot.GetSubKeyNames())
                    {
                        Exception exception = null;
                        try
                        {
                            toCheck.AddLast(registryKeyRoot.OpenSubKey(sub, false));
                        }
                        catch (Exception e)
                        {
                            exception = e;
                        }
                        finally
                        {
                            if (!quiet)
                            {
                                Console.WriteLine(null != exception ? $"{sub} {exception.Message}" : $"{sub} ok");
                            }
                        }
                    }
                }
            }
        }
    }
}
