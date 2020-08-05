using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdvertisingCampaign
{
    public static class AdvertisingCampaign
    {
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string connectionString = AdvertisingCampaignContext.GetConnectionString("AdvertisingCampaignContext");
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
    }
}
