using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab1
{
    public class SumHandler : IHttpHandler
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
            //write your handler implementation here.
            var reqParams = context.Request.Form;
            var result = $"X + Y = {int.Parse(reqParams.Get("X")) + int.Parse(reqParams.Get("Y"))}";
            context.Response.Write(result);
        }

        #endregion
    }
}
