using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        [HttpGet]
        [Route("{iVal:int}/{sVal}")]
        public string M01B(int iVal, string sVal)
        {
            return "Get:M01:/" + iVal + "/" + sVal;
        }

        [Route("{bVal:bool}/{sVal:alpha}")]
        public string M02(bool bVal, string sVal)
        {
            return Request.HttpMethod + ":M02:/" + bVal + "/" + sVal;
        }

        [AcceptVerbs("GET", "DELETE")]
        public string M03(float fVal, string sVal)
        {
            return Request.HttpMethod + ":M03:/" + fVal + "/" + sVal;
        }

        [HttpPut]
        [Route("{sVal:length(3,4)}/{iVal:int:min(100):max(200)}")]
        public string M04(string sVal, int iVal)
        {
            return "PUT:M04:/" + sVal + "/" + iVal;
        }

        [HttpPost]
        [Route(@"{sMail:regex()}")]
        public string M05(string sMail)
        {
            return "Post:mail = " + sMail;
        }
    }
}