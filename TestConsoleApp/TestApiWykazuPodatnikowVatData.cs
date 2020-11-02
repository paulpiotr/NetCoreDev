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
                    ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData apiWykazuPodatnikowVatData = new ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData();
                    ApiWykazuPodatnikowVatData.Models.Entity entity = null;
                    List<ApiWykazuPodatnikowVatData.Models.Entity> entityList = null;
                    ApiWykazuPodatnikowVatData.Models.EntityCheck entityCheck = null;
                    //Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>> lazyEntityList = null;

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipAsync(5731029185) { DateTime.Now.AddDays(i) }");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByNipAsync("5731029185", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entity?.Id } { entity?.Nip } { entity?.DateOfChecking }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@"ApiFindByRegonAsync(150122758)");
                    //    entity = await apiWykazuPodatnikowVatData.ApiFindByRegonAsync("150122758", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entity?.Id } { entity?.Regon } { entity?.DateOfChecking }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountAsync(28195000012006086109200002) { DateTime.Now.AddDays(i) }");
                    //    //entityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync("28195000012006086109200002").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync("28195000012006086109200002", DateTime.Now.AddDays(i));
                    //    Console.WriteLine($"Found { entityList?.Count } { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.DateOfChecking } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByNipsAsync(5731029185,7561967341) { DateTime.Now.AddDays(i) }");
                    //    //lazyEntityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault().DateOfChecking }  ");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByRegonsAsync(150122758,160384226) { DateTime.Now.AddDays(i) }");
                    //    //lazyEntityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByRegonsAsync("150122758,160384226").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByRegonsAsync("150122758,160384226", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } { entityList?.FirstOrDefault()?.DateOfChecking }");
                    //}

                    //for (int i = -7; i <= 0; i++)
                    //{
                    //    Console.WriteLine(@$"Find ApiFindByBankAccountsAsync(28195000012006086109200002,91160013291849460480000032) { DateTime.Now.AddDays(i) }");
                    //    //lazyEntityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => apiWykazuPodatnikowVatData.ApiFindByBankAccountsAsync("28195000012006086109200002,91160013291849460480000032").Result);
                    //    entityList = await apiWykazuPodatnikowVatData.ApiFindByBankAccountsAsync("28195000012006086109200002,91160013291849460480000032", DateTime.Now.AddDays(i));
                    //    Console.WriteLine(@$"Found { entityList?.FirstOrDefault()?.Id } { entityList?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber }  { entityList?.FirstOrDefault()?.DateOfChecking } ");
                    //}

                    for (int i = -7; i <= 0; i++)
                    {
                        Console.WriteLine(@$"Check ApiCheckBankAccountByNipAsync(28195000012006086109200002,91160013291849460480000032) { DateTime.Now.AddDays(i) }");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync("5731029185", "91160013291849460480000032", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked {entityCheck?.Id} {entityCheck?.Nip} {entityCheck?.RequestDateTime} {entityCheck?.RequestId} {entityCheck?.AccountAssigned}");

                        Console.WriteLine(@$"Check ApiCheckBankAccountByRegonAsync(28195000012006086109200002,91160013291849460480000032) { DateTime.Now.AddDays(i) }");
                        entityCheck = await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync("150122758", "30109017950000000113658057", DateTime.Now.AddDays(i));
                        Console.WriteLine($"Checked {entityCheck?.Id} {entityCheck?.Nip} {entityCheck?.RequestDateTime} {entityCheck?.RequestId} {entityCheck?.AccountAssigned}");
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
