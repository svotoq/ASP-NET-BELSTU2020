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

        [HttpDelete]
        [HttpGet]
        [Route("{fVal:float}/{sVal:length(2,5)}")]
        public string M03(float fVal, string sVal)
        {
            return Request.HttpMethod + ":M02:/" + fVal + "/" + sVal;
        }

        [HttpPut]
        [Route("{sVal:length(3,4)}/{iVal:int:min(100):max(200)}")]
        public string M04(string sVal, int iVal)
        {
            return "PUT:M02:/" + sVal + "/" + sVal;
        }

        [HttpPost]
        [Route(@"{sMail:regex(^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$)}")]
        public string M05(string sMail)
        {
            return "Post:mail = " + sMail;
        }
    }
}