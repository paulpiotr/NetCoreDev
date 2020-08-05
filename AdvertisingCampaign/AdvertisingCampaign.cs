using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

/// <summary>
/// Advertising Campaign
/// </summary>
namespace AdvertisingCampaign
{
    /// <summary>
    /// Advertising Campaign
    /// </summary>
    public static class AdvertisingCampaign
    {
        /// <summary>
        /// log4net
        /// </summary>
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// String database connection
        /// </summary>
        private static readonly string connectionString = AdvertisingCampaignContext.GetConnectionString("AdvertisingCampaignContext");
        /// <summary>
        /// Listing Advertising Campaign
        /// </summary>
        /// <returns>List of Advertising Campaign Model or null</returns>
        public static List<Models.AdvertisingCampaign> Index()
        {
            try
            {
                List<Models.AdvertisingCampaign> advertisingCampaign = new List<Models.AdvertisingCampaign>();
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    advertisingCampaign = dbConnection.QueryAsync<Models.AdvertisingCampaign>("SELECT * FROM dbo.AdvertisingCampaign").Result.ToList();
                    if (null != advertisingCampaign && advertisingCampaign.Count > 0)
                    {
                        return advertisingCampaign;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
        /// <summary>
        /// Create Async Advertising Campaign
        /// </summary>
        /// <param name="advertisingCampaign">Advertising Campaign Model</param>
        /// <returns>Advertising Campaign Model or null</returns>
        public static async System.Threading.Tasks.Task<Models.AdvertisingCampaign> CreateAsync(Models.AdvertisingCampaign advertisingCampaign)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    advertisingCampaign = await dbConnection.GetAsync<Models.AdvertisingCampaign>(await dbConnection.InsertAsync<Models.AdvertisingCampaign>(advertisingCampaign));
                    if (null != advertisingCampaign)
                    {
                        return advertisingCampaign;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
        /// <summary>
        /// Find Async Advertising Campaign
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <returns>Advertising Campaign Model or null</returns>
        public static async System.Threading.Tasks.Task<Models.AdvertisingCampaign> FindAsync(int? id = null)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    Models.AdvertisingCampaign advertisingCampaign = await dbConnection.GetAsync<Models.AdvertisingCampaign>(id);
                    if (null != advertisingCampaign)
                    {
                        return advertisingCampaign;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
        /// <summary>
        /// Update Async Advertising Campaign
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <returns>Advertising Campaign Model or null</returns>
        public static async System.Threading.Tasks.Task<Models.AdvertisingCampaign> UpdateAsync(int? id, Models.AdvertisingCampaign advertisingCampaign)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    bool updateAsync = await dbConnection.UpdateAsync(advertisingCampaign);
                    if (updateAsync)
                    {
                        advertisingCampaign = await dbConnection.GetAsync<Models.AdvertisingCampaign>(id);
                        if (null != advertisingCampaign)
                        {
                            return advertisingCampaign;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
        /// <summary>
        /// Delete Async Advertising Campaign
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <param name="advertisingCampaign">Advertising Campaign Model </param>
        /// <returns>Advertising Campaign Model or null</returns>
        public static async System.Threading.Tasks.Task<Models.AdvertisingCampaign> DeleteAsync(int? id, Models.AdvertisingCampaign advertisingCampaign)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    bool deleteAsync = await dbConnection.DeleteAsync(advertisingCampaign);
                    if (deleteAsync)
                    {
                        return advertisingCampaign;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return null;
            }
        }
    }
}