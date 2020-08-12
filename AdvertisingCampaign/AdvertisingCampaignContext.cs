using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AdvertisingCampaign
{
    internal class AdvertisingCampaignContext
    {
        /// <summary>
        /// Stała - nazwa połączenia do bazy danych
        /// </summary>
        private const string connectionStringName = "AdvertisingCampaignContext";
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            try
            {
                return GetConnectionString(connectionStringName);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionStringName)
        {
            try
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configurationRoot = configurationBuilder.Build();
                string connectionString = configurationRoot.GetConnectionString(connectionStringName);
                if (!string.IsNullOrWhiteSpace(connectionString) && connectionString.Contains("%AppDomain.CurrentDomain.BaseDirectory%"))
                {
                    return connectionString.Replace("%AppDomain.CurrentDomain.BaseDirectory%", AppDomain.CurrentDomain.BaseDirectory);
                }
                else if(!string.IsNullOrWhiteSpace(connectionString) && connectionString.Contains("%Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData%"))
                {
                    return connectionString.Replace("%Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Replace("%System.Reflection.Assembly.GetExecutingAssembly().GetName().Name%", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                }
                else if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return connectionString;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <returns></returns>
        public static string GetDecryptConnectionString()
        {
            try
            {
                return GetDecryptConnectionString(connectionStringName);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static string GetDecryptConnectionString(string connectionStringName)
        {
            try
            {
                string rsaFileContent = EncryptDecrypt.EncryptDecrypt.GetRsaFileContent();
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configurationRoot = configurationBuilder.Build();
                string connectionString = configurationRoot.GetConnectionString(connectionStringName);
                connectionString = EncryptDecrypt.EncryptDecrypt.DecryptString(connectionString, rsaFileContent);
                if (!string.IsNullOrWhiteSpace(connectionString) && connectionString.Contains("%AppDomain.CurrentDomain.BaseDirectory%"))
                {
                    return connectionString.Replace("%AppDomain.CurrentDomain.BaseDirectory%", AppDomain.CurrentDomain.BaseDirectory);
                }
                else if (!string.IsNullOrWhiteSpace(connectionString) && connectionString.Contains("%Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData%"))
                {
                    return connectionString.Replace("%Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Replace("%System.Reflection.Assembly.GetExecutingAssembly().GetName().Name%", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                }
                else if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    return connectionString;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <returns></returns>
        public static DbContextOptions<Models.AdvertisingCampaignContext> GetDecryptConnectionOptionsBuilder()
        {
            try
            {
                DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder<Models.AdvertisingCampaignContext>();
                dbContextOptionsBuilder.UseSqlServer(GetDecryptConnectionString());
                return (DbContextOptions<Models.AdvertisingCampaignContext>)dbContextOptionsBuilder.Options;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Konfiguracja zaszyfrowanego połączenia do bazy danych kontekstu Models.AdvertisingCampaignContext
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DbContextOptions<Models.AdvertisingCampaignContext> GetConnectionOptionsBuilder(string connectionString)
        {
            try
            {
                DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder<Models.AdvertisingCampaignContext>();
                dbContextOptionsBuilder.UseSqlServer(connectionString);
                return (DbContextOptions<Models.AdvertisingCampaignContext>)dbContextOptionsBuilder.Options;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Testowanie połączenia SQL
        /// </summary>
        /// <param name="connectionString">The sqlConnection string</param>
        /// <returns>true if the sqlConnection is opened</returns>
        public static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    try
                    {
                        sqlConnection.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
