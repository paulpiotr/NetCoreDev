using Microsoft.EntityFrameworkCore;
using PortalApiGusApiRegonData;
using System;
using System.IO;

namespace TestConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            string s = string.Empty;

            s = NetAppCommon.DataConfiguration.GetAppSettingsPath();
            Console.WriteLine(s);
            s = await NetAppCommon.DataConfiguration.GetAppSettingsPathAsync();
            Console.WriteLine(s);

            //NetAppCommon.DataConfiguration.GetConfigurationRoot();
            //await NetAppCommon.DataConfiguration.GetConfigurationRootAsync();

            //s = NetAppCommon.DataConfiguration.GetValue<string>("ConnectionStrings:PortalApiGusApiRegonData");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DataConfiguration.GetValueAsync<string>("ConnectionStrings:PortalApiGusApiRegonData");
            //Console.WriteLine(s);

            //NetAppCommon.DataConfiguration.SetAppSettingValue<string>("Lipa", "Lipa");
            //await NetAppCommon.DataConfiguration.SetAppSettingValueAsync<string>("Lipa", "Lipa");

            //s = NetAppCommon.DataContext.GetConnectionString("TestConnection");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DataContext.GetConnectionStringAsync("TestConnection");
            //Console.WriteLine(s);

            //s = NetAppCommon.DataContext.GetDecryptConnectionString("PortalApiGusApiRegonData", "id_rsa.ppk.pub");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DataContext.GetDecryptConnectionStringAsync("PortalApiGusApiRegonData", "id_rsa.ppk.pub");
            //Console.WriteLine(s);

            //s = NetAppCommon.DataContext.GetDecryptConnectionString("ala", "ma");
            //Console.WriteLine(s);
            //s = await NetAppCommon.DataContext.GetDecryptConnectionStringAsync("ala", "ma");
            //Console.WriteLine(s);

            //s = NetAppCommon.DataContext.GetSqlServerDbContextOptions<DbContext>("TestConnection").ContextType.;
            //Console.WriteLine(s);

            //DbContext dbContext = NetAppCommon.DataContext.GetSqlServerDbContext<DbContext>("TestConnection");
            //Console.WriteLine(dbContext.Database.CanConnect());
            //Console.WriteLine(dbContext.Database.GetDbConnection().ConnectionString);

            //PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = (PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext)NetAppCommon.DataContext.GetSqlServerDbContext<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonData");

            //PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = NetAppCommon.DataContext.CreateInstancesForDatabaseContextClass<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonData");

            //if (null != portalApiGusApiRegonDataDbContext)
            //{
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.GetDbConnection().ConnectionString);
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.CanConnect());
            //    Console.WriteLine(portalApiGusApiRegonDataDbContext.GetType());
            //}

            var portalApiGusApiRegonDataDbContext = await NetAppCommon.DataContext.DecryptAndCreateInstancesForDatabaseContextClassAsync<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("PortalApiGusApiRegonDataDbContext", "id_rsa.ppk.pub");
            if (null != portalApiGusApiRegonDataDbContext)
            {
                Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.GetDbConnection().ConnectionString);
                Console.WriteLine(portalApiGusApiRegonDataDbContext.Database.CanConnect());
                Console.WriteLine(portalApiGusApiRegonDataDbContext.GetType());
            }

            //DbContextOptions dbContextOptions = NetAppCommon.DataContext.GetSqlServerDbContextOptions<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>("TestConnection");
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
