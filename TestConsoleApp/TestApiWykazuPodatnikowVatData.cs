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
                    ApiWykazuPodatnikowVatData.Models.Entity entity = null;
                    Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>> entityList = null;
                    ApiWykazuPodatnikowVatData.Models.EntityCheck entityCheck = null;

                    Console.WriteLine(@"Find ApiFindByNipAsync(5731029185)");
                    entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByNipAsync("5731029185");
                    Console.WriteLine($"Found { entity.Id } { entity.Nip }");

                    Console.WriteLine(@"ApiFindByRegonAsync(150122758)");
                    entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByRegonAsync("150122758");
                    Console.WriteLine($"Found { entity.Id } { entity.Regon }");

                    Console.WriteLine(@"Find ApiFindByBankAccountAsync(28195000012006086109200002)");
                    entityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByBankAccountAsync("28195000012006086109200002").Result);
                    Console.WriteLine($"Found { entityList.Value?.FirstOrDefault()?.Id } { entityList.Value?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } ");

                    Console.WriteLine(@"Find ApiFindByNipsAsync(5731029185,7561967341)");
                    entityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByNipsAsync("5731029185,7561967341").Result);
                    Console.WriteLine($"Found { entityList.Value?.FirstOrDefault()?.Id } { entityList.Value?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } ");

                    Console.WriteLine(@"Find ApiFindByRegonsAsync(150122758,160384226)");
                    entityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByRegonsAsync("150122758,160384226").Result);
                    Console.WriteLine($"Found { entityList.Value?.FirstOrDefault()?.Id } { entityList.Value?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } ");

                    Console.WriteLine(@"Find ApiFindByBankAccountsAsync(28195000012006086109200002,91160013291849460480000032)");
                    entityList = new Lazy<List<ApiWykazuPodatnikowVatData.Models.Entity>>(() => ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByBankAccountsAsync("28195000012006086109200002,91160013291849460480000032").Result);
                    Console.WriteLine($"Found { entityList.Value?.FirstOrDefault()?.Id } { entityList.Value?.FirstOrDefault()?.EntityAccountNumber?.FirstOrDefault()?.AccountNumber } ");

                    Console.WriteLine(@"Check ApiCheckBankAccountByNipAsync(28195000012006086109200002,91160013291849460480000032)");
                    entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync("5731029185", "91160013291849460480000032");
                    Console.WriteLine($"Checked {entityCheck?.Id} {entityCheck?.Nip} {entityCheck?.RequestDateTime} {entityCheck?.RequestId} {entityCheck?.AccountAssigned}");

                    Console.WriteLine(@"Check ApiCheckBankAccountByRegonAsync(28195000012006086109200002,91160013291849460480000032)");
                    entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync("150122758", "30109017950000000113658057");
                    Console.WriteLine($"Checked {entityCheck?.Id} {entityCheck?.Nip} {entityCheck?.RequestDateTime} {entityCheck?.RequestId} {entityCheck?.AccountAssigned}");
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message, e.StackTrace);
            }
        }
    }
}
