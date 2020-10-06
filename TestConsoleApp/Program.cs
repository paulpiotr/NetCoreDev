using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsoleApp
{
    internal class Program
    {
        private static async System.Threading.Tasks.Task Main(string[] args)
        {

            NetAppCommon.DatabaseMssql.CanConnect(@"Server=.\SQLExpress; Database=IUIntegrationSystemData; MultipleActiveResultSets=true; User Id=IUIntegrationSystemDataApi; Password=pTdp/6P:Z-ZP86dS%Q:U!ZK34`2UvB=v;");
            Console.ReadKey();

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

            Console.ReadKey();

            //RabbitMQPublisherCommon.RabbitMQPublisherCommon.Publish("TestConsoleApp", "From TestConsoleApp");
            //string s = string.Empty;

            //s = NetAppCommon.Configuration.GetAppSettingsPath();
            //Console.WriteLine(s);
            //s = await NetAppCommon.Configuration.GetAppSettingsPathAsync();
            //Console.WriteLine(s);

            //NetAppCommon.Configuration.GetConfigurationRoot();
            //await NetAppCommon.Configuration.GetConfigurationRootAsync();

            //s = NetAppCommon.Configuration.GetValue<string>("ConnectionStrings:PortalApiGusApiRegonData");
            //Console.WriteLine(s);
            //s = await NetAppCommon.Configuration.GetValueAsync<string>("ConnectionStrings:PortalApiGusApiRegonData");
            //Console.WriteLine(s);

            //NetAppCommon.Configuration.SetAppSettingValue<string>("Lipa", "Lipa");
            //await NetAppCommon.Configuration.SetAppSettingValueAsync<string>("Lipa", "Lipa");

            //s = NetAppCommon.DatabaseMssql.GetConnectionString("TestConnection");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DatabaseMssql.GetConnectionStringAsync("TestConnection");
            //Console.WriteLine(s);

            //s = NetAppCommon.DatabaseMssql.GetDecryptConnectionString("PortalApiGusApiRegonData", "id_rsa.ppk.pub");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DatabaseMssql.GetDecryptConnectionStringAsync("PortalApiGusApiRegonData", "id_rsa.ppk.pub");
            //Console.WriteLine(s);

            //s = NetAppCommon.DatabaseMssql.GetDecryptConnectionString("ala", "ma");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DatabaseMssql.GetDecryptConnectionStringAsync("ala", "ma");
            //Console.WriteLine(s);

            //s = NetAppCommon.DatabaseMssql.GetSqlServerDbContextOptions<DbContext>("TestConnection").ContextType.;
            //Console.WriteLine(s);

            //DbContext dbContext = NetAppCommon.DatabaseMssql.GetSqlServerDbContext<DbContext>("TestConnection");
            //Console.WriteLine(dbContext.Database.CanConnect());
            //Console.WriteLine(dbContext.Database.GetDbConnection().ConnectionString);

            //PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = (PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext)NetAppCommon.DatabaseMssql.GetSqlServerDbContext<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonData");

            //PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClass<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonData");

            //if (null != portalApiGusApiRegonDataDbContext)
            //{
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.GetDbConnection().ConnectionString);
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.CanConnect());
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.GetType());
            //}

            //var portalApiGusApiRegonDataDbContext = await NetAppCommon.DatabaseMssql.DecryptAndCreateInstancesForDatabaseContextClassAsync<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonDataDbContext", "id_rsa.ppk.pub");
            //if (null != portalApiGusApiRegonDataDbContext)
            //{
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.GetDbConnection().ConnectionString);
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.CanConnect());
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.GetType());
            //}

            //DbContextOptions dbContextOptions = NetAppCommon.DatabaseMssql.GetSqlServerDbContextOptions<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("TestConnection");
            //Console.WriteLine(dbContextOptions.ContextType.Name);

            //IcasaMutationServiceData.IcasaMutationServiceData.Test();
            //await RabbitMQPublisherTest.RabbitMQPublisher.TestRabbitMQPublisherAsync();
            //var array = new[] { 1, 2, 3, 4, 5, 6 };
            //var rand = new Random().Next(array.Length);
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrsy("b65986a6300044a0b7fb", krsy: "0000349095,0000387233");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip("b65986a6300044a0b7fb", nip: "5730207319");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipy("b65986a6300044a0b7fb", nipy: "5730207319,5321052523");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegon("b65986a6300044a0b7fb", regon: "001337730");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn ("b65986a6300044a0b7fb", regony9zn: "001337730,366316484");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn("b65986a6300044a0b7fb", regony14zn: "001337730,366316484");
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");

            //Inergis
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", nip: "5730207319");
            //Isk
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", krs: "0000349095");
            //Stylmeb
            //await DanePobierzPelnyRaport.DanePobierzPelnyRaportAsync("b65986a6300044a0b7fb", nip: "5321052523");
            //5321052523
        }
    }
}