using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace lab5.Controllers
{
    public class CResearchController : Controller
    {
        [Route("~/CResearch")]
        [Route("~/CResearch/C01")]
        public string C01(string Name)
        {
            string headers = String.Empty;
            foreach (var key in Request.Headers.AllKeys)
                headers += key + "=" + Request.Headers[key] + "<br/>";
            string body = "None";
            if (Name != null)
            {
                body = "Name: " + Name;
            }
            return "<b>Method:</b> " + Request.HttpMethod.ToString() + "<br/>" +
                "<b>Query-Parameters:</b> " + Request.QueryString.ToString() + "<br/>" +
                "<b>Uri:</b> " + Request.Url.ToString() + "<br/>" +
                "<b>Headers:</b> " + headers + "<br/>" +
                "<b>Body:</b> " + body + "<br/>";
        }

        [Route("~/CResearch/C02")]
        public string C02(string Name)
        {
            string headers = String.Empty;
            foreach (var key in Request.Headers.AllKeys)
                headers += key + "=" + Request.Headers[key] + "<br/>";
            string body = "None";
            if (Name != null)
            {
                body = "Name: " + Name;
            }
            return "<b>Status:</b> " + Response.Status + "<br/>" +
                "<b>Headers:</b> " + headers + "<br/>" +
                "<b>Body:</b> " + body + "<br/>";
        }
    }
}