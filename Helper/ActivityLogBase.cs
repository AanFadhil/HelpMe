using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Helper
{
    public abstract class ActivityLogBase
    {
        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Activity { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Data { get; set; }
        public LogType Type { get; set; }

        public ActivityLogBase()
        {

        }

        public ActivityLogBase(HttpRequest request, string activity, string userName)
        {
            this.HostName = request.UserHostName;
            this.IPAddress = request.UserHostAddress;
            this.UserName = userName;
            this.Activity = activity;
            this.Data = "";
        }

        public abstract void InsertLog();

        public static string SqlParamToString(List<SqlParameter> parameters)
        {
            string result = "";

            foreach (var item in parameters)
            {
                result += item.ParameterName + " : " + item.Value.ToString() + " ; ";
            }
            return result;
        }

        public static string SqlParamToString(SqlParameterCollection parameters)
        {
            string result = "";

            foreach (SqlParameter item in parameters)
            {
                string value = "";

                try
                {



                    if (item.SqlDbType == SqlDbType.Structured)
                    {
                        System.IO.StringWriter sw = new System.IO.StringWriter();
                        var dt = (DataTable)item.Value;
                        dt.TableName = item.ParameterName;

                        dt.WriteXml(sw);

                        value = sw.ToString();
                    }
                    else
                    {
                        value = item.Value.ToString();
                    }

                    result += item.ParameterName + " : " + value + " ; ";
                }
                catch
                {

                }
            }

            return result;
        }

        public enum LogType
        {
            Error,
            Success,
            Failed
        }
    }
}
