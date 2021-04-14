using System;

namespace TestConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var test = new NetAppCommon.AppSettings.Repositories.Base.AppSettingsRepositoryBase<NetAppCommon.AppSettings.Models.AppSettings>().MssqlCheckConnectionString(@"Server=(local)\SQLEXPRESS; Database=NowaBazaWWW; Uid=sa; Pwd=NIEznaszhasla111; Max Pool Size=65536; Pooling=True; MultipleActiveResultSets=true;");
            //Console.WriteLine(test);

            return;

            //var appSettings = new PortalApiGusApiRegonData.Models.AppSettings();

            //Console.WriteLine(appSettings.GetConnectionString());

            //var appSettings = Vies.Core.Database.Models.AppSettings.GetInstance();


            //Console.WriteLine(appSettings.RsaProviderService.AsymmetricPublicKeyAsString);

            //Console.WriteLine(appSettings.GetConnectionString());

            //Console.WriteLine(appSettings.RsaProviderService.EncryptWithPrivateKey("0"));

            //NetAppCommon.Crypto.BouncyCastle.Services.RsaProviderService rsaProviderService = appSettings.RsaProviderService;
            ////var rsaProviderService = new NetAppCommon.Crypto.BouncyCastle.Services.RsaProviderService();

            //Console.WriteLine(rsaProviderService.AsymmetricPublicKeyAsString);
            //Console.WriteLine(rsaProviderService.AsymmetricPrivateKeyAsString);

            //var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=%Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)%\\MSSQLLocalDB\\MSSQLLocalDB.mdf; Database=%AttachDbFilename%; MultipleActiveResultSets=true; Integrated Security=SSPI; Trusted_Connection=Yes; Max Pool Size=65536; Pooling=True";
            /////appSettings.GetConnectionString();
            ////var encrypt = rsaProviderService.EncryptWithPrivateKey(connectionString);
            ////var test1 = rsaProviderService.DecryptWithPrivateKey(encrypt);
            ////var test2 = rsaProviderService.DecryptWithPublicKey(encrypt);
            ////Console.WriteLine($" \n\n{connectionString} \n\n{encrypt} \n\n{test1} \n\n{test2} ");

            //var aesIVProviderService = new NetAppCommon.Crypto.AesCryptography.Services.AesIVProviderService();
            //var encrypt = aesIVProviderService.Encrypt(rsaProviderService.EncryptWithPrivateKey(connectionString), rsaProviderService.AsymmetricPublicKeyAsString);
            //var decrypt = aesIVProviderService.Decpypt(encrypt, rsaProviderService.AsymmetricPublicKeyAsString);

            //Console.WriteLine($"{ encrypt }\n\n{ rsaProviderService.DecryptWithPublicKey(decrypt) }");

            //Console.WriteLine($"{ appSettings.RsaProviderService.EncryptWithPrivateKey(appSettings.ConnectionString) }");

            //IsPrime(2);

            //var encrypt = appSettings.RsaProviderService.EncryptWithPrivateKey("encrypt");
            //Console.WriteLine($"{ appSettings.FilePath }");

            //Console.WriteLine($"{ appSettings.AsymmetricPrivateKeyFilePath }");
            //Console.WriteLine($"{ appSettings.AsymmetricPrivateKeyAsString }");

            //Console.WriteLine($"{ appSettings.AsymmetricPublicKeyFilePath }");
            //Console.WriteLine($"{ appSettings.AsymmetricPublicKeyAsString }");

            //Console.WriteLine($"{ appSettings.ConnectionString } { appSettings.ConnectionString.Length }");

            ///var ecs = appSettings.RsaProviderService.EncryptWithPrivateKey(appSettings.ConnectionString, appSettings.AsymmetricPrivateKeyAsString);

            ///Console.WriteLine($"{ ecs } { ecs.Length }");

            ///ecs = appSettings.RsaProviderService.EncryptWithPrivateKey("1", appSettings.AsymmetricPrivateKeyAsString);

            ///Console.WriteLine($"{ ecs } { ecs.Length }");


            //var rsaServiceProvider = new NetAppCommon.Crypto.BouncyCastle.Services.RsaProviderService(
            //    appSettings.AsymmetricPrivateKeyFilePath,
            //    appSettings.AsymmetricPublicKeyFilePath,
            //    true
            //    );


            ////var specialFolderDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            ////var rsaServiceProvider = new NetAppCommon.Crypto.BouncyCastle.Services.RsaProviderService(
            ////    Path.Combine(specialFolderDesktopPath, "Klucze", "id_rsa"),
            ////    Path.Combine(specialFolderDesktopPath, "Klucze", "id_rsa.pub"),
            ////    true
            ////    );


            //Console.WriteLine($"{ rsaServiceProvider.AsymmetricPrivateKeyAsString }");
            //Console.WriteLine($"{ rsaServiceProvider.AsymmetricPublicKeyAsString }");

            //var text = appSettings.ConnectionString;
            //var encrypt = rsaServiceProvider.EncryptWithPrivateKey(text);
            //Console.WriteLine(rsaServiceProvider.DecryptWithPrivateKey(encrypt));

            //Console.WriteLine(rsaServiceProvider.DecryptWithPublicKey(encrypt));

            //id_rsa and the public key named id_rsa.pub
            //rsaServiceProvider.SaveAsymmetricKeyPairToFile();

            //var publicKeyParam = DotNetUtilities.GetRsaPublicKey(rsa.ExportParameters(false));
            //var publicKey = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKeyParam).GetDerEncoded();


            //var appSettings = new NetAppCommon.AppSettings.Models.AppSettingsModel();
            //var appSettingsRepository = new NetAppCommon.AppSettings.Repositories.AppSettingsRepository();
            //Console.WriteLine($"{ appSettings.FileName } { appSettings.FilePath } { appSettings.GetConnectionString() }");
            ////appSettings.ConnectionString = "Nowa wartość ustawienia";
            ////appSettings = NetAppCommon.AppSettings.Repositories.AppSettingsRepository.GetInstance().MergeAndCopyToUserDirectory(appSettings);
            //Console.WriteLine($"{ appSettings.FileName } { appSettings.FilePath } { appSettings.GetConnectionString() }");
            //Console.WriteLine($"{ appSettings.BaseDirectory } { appSettings.UserProfileDirectory } ");
            //var portalApiGusKey = await appSettingsRepository.GetValueAsync<string>("PortalApiGusKey");
            //Console.WriteLine($" { portalApiGusKey } { await appSettingsRepository.GetValueAsync<string>("PortalApiGusKey") } ");

            //var appSettings = new Vies.Core.Database.Models.AppSettings();
            //appSettings = new Vies.Core.Database.Models.AppSettings();
            //appSettings = new Vies.Core.Database.Models.AppSettings();

            //Console.WriteLine($"{ appSettings.FileName } { appSettings.FilePath } { appSettings.GetConnectionString() }");
            //Console.WriteLine($"{ appSettings.BaseDirectory } { appSettings.UserProfileDirectory } ");
            //Console.WriteLine($"{ appSettings.LastMigrateDateTime } ");
            //await appSettings.AppSettingsRepository.SaveAsync(appSettings);
            //appSettings.LastMigrateDateTime = DateTime.Now;
            //await appSettings.AppSettingsRepository.SaveAsync(appSettings);

            //Microsoft.EntityFrameworkCore.DbContextOptions<ViesCoreDatabaseContext> dbContextOptions = appSettings.GetDbContextOptions<ViesCoreDatabaseContext>();
            //var viesCoreDatabaseContext = new ViesCoreDatabaseContext(dbContextOptions);

            //Console.WriteLine($"{ appSettings.FileName } { appSettings.FilePath } { appSettings.GetConnectionString() } { appSettings.GetConnectionString() }");

            //Console.WriteLine($" { await viesCoreDatabaseContext.Database.CanConnectAsync() } ");

            //appSettingsRepository.GetValueAsync<string>("PortalApiGusKey");
            //await NetAppCommon.AppSettings.Repositories.AppSettingsRepository.GetInstance().MergeAsync(appSettings);
            //NetAppCommon.AppSettings.Repositories.AppSettingsRepository()
            //Console.WriteLine($"{ appSettings.FileName } { appSettings.GetFilePath() }");
            //Console.WriteLine($"{ appSettings.FileName } { appSettings.GetFilePath() }");
            //Console.WriteLine($"{ appSettings.GetConnectionStringName() } { appSettings.ConnectionStringName }");
            //Console.WriteLine($"{ appSettings.GetConnectionString() } { appSettings.ConnectionString }");
            //Microsoft.EntityFrameworkCore.DbContextOptionsBuilder dbContextOptionsBuilder = new NetAppCommon.AppSettings.Models.AppSettingsModel().GetDbContextOptionsBuilder<Vies.Core.Database.Data.ViesCoreDatabaseContext>();
            //Console.WriteLine(dbContextOptionsBuilder?.Options?.ContextType?.FullName);
            //Microsoft.EntityFrameworkCore.DbContextOptions dbContextOptions = new NetAppCommon.AppSettings.Models.AppSettingsModel().GetDbContextOptions<Vies.Core.Database.Data.ViesCoreDatabaseContext>();
            //Console.WriteLine(dbContextOptions?.ContextType?.FullName);

            //await WFAttachmentFiles.AttachWFAttachmentFilesAsync();

            //string xml = File.ReadAllText(@"e:\test.xml");
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //string json = JsonConvert.SerializeXmlNode(doc);
            //File.WriteAllText(@"e:\test.json", json);


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

            //NetAppCommon.DatabaseMssql.ParseConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=%Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)%\MSSQLLocalDB\MSSQLLocalDB.mdf; Database=%AttachDBFilename%; MultipleActiveResultSets=true; Integrated Security=SSPI; Trusted_Connection=Yes");

            //NetAppCommon.DatabaseMssql.ParseConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=%Environment.GetFolderPath(Environment.SpecialFolder.Programs)%\MSSQLLocalDB\MSSQLLocalDB.mdf; Database=%AttachDBFilename%; MultipleActiveResultSets=true; Integrated Security=SSPI; Trusted_Connection=Yes");

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

