using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    public class CResearchController : Controller
    {
        [Route("~/CResearch")]
        [Route("~/CResearch/C01")]
        public string C01()
        {
            string headers = String.Empty;
            foreach (var key in Request.Headers.AllKeys)
                headers += key + "=" + Request.Headers[key] + "<br/>";
            return "<b>Method:</b> " + Request.HttpMethod.ToString() + "<br/>" +
                "<b>Query-Parameters:</b> " + Request.QueryString.ToString() + "<br/>" +
                "<b>Uri:</b> " + Request.Url.ToString() + "<br/>" +
                "<b>Headers:</b> " + headers + "<br/>" +
                "<b>Body:</b> " + Request.ReadEntityBodyMode.ToString() + "<br/>";
        }

        [Route("~/CResearch/C02")]
        public string C02()
        {
            string headers = String.Empty;
            foreach (var key in Request.Headers.AllKeys)
                headers += key + "=" + Request.Headers[key] + "<br/>";
            return "<b>Status:</b> " + Response.Status+ "<br/>" +
                "<b>Headers:</b> " + headers + "<br/>" +
                "<b>Body:</b> " + Request.ReadEntityBodyMode.ToString() + "<br/>";
        }
    }
}