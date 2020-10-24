using System;
using System.Web;

namespace Lab1
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var reqParams = context.Request.Params;
            string result = String.Empty;
            switch (context.Request.RequestType)
            {
                case "GET":
                    {
                        result = "GET";
                        break;
                    }
                case "POST":
                    {
                        result = "POST";
                        break;
                    }
                case "PUT":
                    {
                        result = "PUT";
                        break;
                    }
            }
            result += $"-Http-PSY:ParmA = {reqParams.Get("ParamA")}, ParmB = { reqParams.Get("ParamB")}";
            context.Response.Write(result);
        }

        #endregion
    }
}
