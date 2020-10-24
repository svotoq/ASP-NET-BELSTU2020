using System;
using System.Web;

namespace Lab1
{
    public class MultHandler : IHttpHandler
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
            var reqParams = context.Request.Form;
            switch(context.Request.RequestType)
            {
                case "GET":
                    {
                        context.Response.WriteFile("../MultPage.html");
                        break;
                    }
                case "POST":
                    {
                        var result = $"{int.Parse(reqParams.Get("InputX")) * int.Parse(reqParams.Get("InputY"))} ";
                        context.Response.Write(result);
                        break;
                    }
            }
        }

        #endregion
    }
}
