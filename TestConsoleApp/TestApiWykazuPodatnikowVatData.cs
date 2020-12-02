using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public static class TestApiWykazuPodatnikowVatData
    {
        public static async Task TestApiWykazuPodatnikowVatDataAsync()
        {
            try
            {
                await Task.Run(async () =>
                {

                    ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext context = new ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext();
                    await context.CheckForUpdateAndMigrateAsync();

                    ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData apiWykazuPodatnikowVatData = new ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData();
                    //ApiWykazuPodatnikowVatData.Models.Entity entity = null;
                    //List<ApiWykazuPodatnikowVatData.Models.Entity> entityList = null;
                    ApiWykazuPodatnikowVatData.Models.EntityCheck entityCheck = null;
                    //Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>> lazyEntityList = null;

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipAsync(5731029185) { DateTime.Now.AddDays(i) }");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByNipAsync("5731029185", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entity?.GetValuesToString(" | ") } { entity?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipAsync(15731029185) { DateTime.Now.AddDays(i) }");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByNipAsync("15731029185", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entity?.Id } { entity?.Nip } { entity?.DateOfChecking } { entity?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@"ApiFindByRegonAsync(150122758)");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByRegonAsync("150122758", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entity?.Id } { entity?.Regon } { entity?.DateOfChecking } { entity?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@"ApiFindByRegonAsync(1150122758)");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByRegonAsync("1150122758", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entity?.Id } { entity?.Regon } { entity?.DateOfChecking } { entity?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountAsync(28195000012006086109200002) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync("28195000012006086109200002", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entityList?.Count } { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountAsync(128195000012006086109200002) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync("128195000012006086109200002", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entityList?.Count } { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipsAsync(5731029185,7561967341) { DateTime.Now.AddDays(i) }");
                    //    //lazyEntityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }  ");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipsAsync(15731029185,17561967341) { DateTime.Now.AddDays(i) }");
                    //    //lazyEntityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByNipsAsync("15731029185,17561967341", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }  ");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByRegonsAsync(150122758,160384226) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByRegonsAsync("150122758,160384226", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") } ");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByRegonsAsync(1150122758,1160384226) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByRegonsAsync("1150122758,1160384226", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") } ");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountsAsync(28195000012006086109200002,91160013291849460480000032) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountsAsync("28195000012006086109200002,91160013291849460480000032", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber }  { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountsAsync(128195000012006086109200002,191160013291849460480000032) { DateTime.Now.AddDays(i) }");
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountsAsync("128195000012006086109200002,191160013291849460480000032", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber }  { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    //}

                    for (int i = -7; i <= 0; i++)
                    {
                        Console.WriteLine(@$"Check ApiCheckBankAccountByNipAsync(5731029185, 28195000012006086109200002, { DateTime.Now.AddDays(i) })");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync("5731029185", "28195000012006086109200002", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Nip } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByNipAsync(5731029185, 67105011421000009030710835, { DateTime.Now.AddDays(i) })");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync("5731029185", "67105011421000009030710835", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Nip } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByNipAsync(15731029185, 167105011421000009030710835, { DateTime.Now.AddDays(i) })");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync("15731029185", "167105011421000009030710835", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Nip } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByRegonAsync(160384226,80105011421000002436657973) { DateTime.Now.AddDays(i) }");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync("160384226", "80105011421000002436657973", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Regon } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByRegonAsync(160384226,167105011421000009030710835) { DateTime.Now.AddDays(i) }");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync("160384226", "167105011421000009030710835", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Regon } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByRegonAsync(1160384226,1167105011421000009030710835) { DateTime.Now.AddDays(i) }");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync("1160384226", "1167105011421000009030710835", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked { entityCheck?.Id } { entityCheck?.Regon } { entityCheck?.AccountAssigned } { entityCheck?.RequestAndResponseHistory?.GetValuesToString(" | ") }");
                    }
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message, e.StackTrace);
            }
        }
    }
}
