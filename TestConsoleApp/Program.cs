using Microsoft.EntityFrameworkCore;
//using PortalApiGusApiRegonData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PortalApiGusApiRegonData;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
//using ApiWykazuPodatnikowVatData;

namespace TestConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            string xml = File.ReadAllText(@"e:\test.xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc);

            File.WriteAllText(@"e:\test.json", json);


            //ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext context = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>();
            //await context.CheckForUpdateAndMigrateAsync();

            //await TestApiWykazuPodatnikowVatData.TestApiWykazuPodatnikowVatDataAsync();

            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");

            //IUIntegrationSystemData.Data.IUIntegrationSystemDataDbContext context = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<IUIntegrationSystemData.Data.IUIntegrationSystemDataDbContext>();

            //await context.CheckForUpdateAndMigrateAsync();

            //List<IUIntegrationSystemData.Models.InvoiceFromIcasaCsv> invoiceFromIcasaCsvList = (List<IUIntegrationSystemData.Models.InvoiceFromIcasaCsv>)await IUIntegrationSystemData.InvoiceFromIcasaCsvData.GetInstance().ImportCsvFileAsync(@"e:\export.csv");

            //Console.WriteLine(invoiceFromIcasaCsvList.Count);

            //foreach (IUIntegrationSystemData.Models.InvoiceFromIcasaCsv invoiceFromIcasaCsv in invoiceFromIcasaCsvList)
            //{
            //    Console.WriteLine(invoiceFromIcasaCsv.Id);
            //    //Console.WriteLine(invoiceFromIcasaCsv.Exception.Message);
            //}

            //Console.WriteLine("Done");
            //Console.Read();

            //PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = NE

            //using (PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext context = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<PortalApiGusApiRegonData.Data.PortalApiGusApiRegonDataDbContext>())
            //{
            //    await context.CheckForUpdateAndMigrateAsync();
            //}
            //await DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");
            //Console.Read();

            //using (ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext context = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>())
            //{
            //    await context.CheckForUpdateAndMigrateAsync();
            //}
            //ApiWykazuPodatnikowVatData.Models.Entity entity = null;
            //Console.WriteLine(@"Find ApiFindByNipAsync(5731029185)");
            //entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByNipAsync("5731029185");
            //Console.WriteLine($"Found { entity.Id } { entity.Nip } { entity.UniqueIdentifierOfTheLoggedInUser }");
            //Console.Read();

            //NetAppCommon.DatabaseMssql.ParseConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=%Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)%\MSSQLLocalDB\MSSQLLocalDB.mdf; Database=%AttachDBFilename%; MultipleActiveResultSets=true; Integrated Security=True; Trusted_Connection=Yes");

            //NetAppCommon.DatabaseMssql.ParseConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=%Environment.GetFolderPath(Environment.SpecialFolder.Programs)%\MSSQLLocalDB\MSSQLLocalDB.mdf; Database=%AttachDBFilename%; MultipleActiveResultSets=true; Integrated Security=True; Trusted_Connection=Yes");

            //PortalApiGusApiRegonData.PortalApiGusApiRegonDataContext.DatabaseMdfCreate();
            //NetAppCommon.DatabaseMssqlMdf.GetInstance

            //NetAppCommon.DatabaseMssqlMdf.GetInstance("PortalApiGusApiRegonData", "PortalApiGusApiRegonData.json").Create();
            //NetAppCommon.DatabaseMssqlMdf.GetInstance().Create("PortalApiGusApiRegonDataDbContext", "portal.api.gus.api.regon.data.appsettings.debug.json");

            //List<PortalApiGusApiRegonData.Models.DaneSzukajPodmioty.DaneSzukajPodmioty> daneSzukajPodmiotyList = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByKrs("b65986a6300044a0b7fb", krs: "0000349095");

            //Console.WriteLine(daneSzukajPodmiotyList.Count);

            //ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext context = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext>();
            //await context.CheckForUpdateAndMigrateAsync();
            //Console.WriteLine("Done... :) ");

            //await TestApiWykazuPodatnikowVatData.TestApiWykazuPodatnikowVatDataAsync();

            //await TestIcasaMutationServiceData.TestIcasaMutationServiceDataAsync();

            //TestFileSystemWatcherCommon.TestFileSystemWatcherCommonWatch();

            //Task fileSystemWatcherInTask = Task.Run(() => {
            //    IUIntegrationSystemData.FileSystemWatcherInvoicesIn fileSystemWatcherInvoicesIn = new IUIntegrationSystemData.FileSystemWatcherInvoicesIn();
            //    fileSystemWatcherInvoicesIn.Watch(@"E:\icasa\in");
            //});

            //Task fileSystemWatcherOutTask = Task.Run(() => {
            //    IUIntegrationSystemData.FileSystemWatcherIn.OnWatch(@"E:\icasa\out");
            //});

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