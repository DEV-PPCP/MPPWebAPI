using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace PPCPWebApiServices.Models.PPCPWebService.DAL
{
    public class Logging
    {
        public static void LogMessage(string source, string errorMessage, string logType, int createdBy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    string ssql = "insert into Logs(source, errorMessage, logType, CreatedDate, createdBy) values(@source, @errorMessage, @logType, getutcdate(), @createdBy) ";
                    conn.Execute(ssql, new { source, errorMessage, logType, createdBy });
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CommonService
    {
        public static List<Application_Parameter_Config> GetApplicationConfigs()
        {
            List<Application_Parameter_Config> list = new List<Application_Parameter_Config>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    string ssql = "select * from Application_Parameter_Config";
                    list = conn.Query<Application_Parameter_Config>(ssql, new { }, commandType: CommandType.Text).ToList();
                }
            }

            catch (Exception ex)
            {

            }
            return list;
        }
    }
}