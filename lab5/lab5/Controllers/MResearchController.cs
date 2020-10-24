using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    [RoutePrefix("MResearch")]
    public class MResearchController : Controller
    {
        //M01
        [HttpGet]
        [Route("M01/{id:int}")]
        [Route("M01")]
        [Route("~/")]
        [Route("~/MResearch")]
        [Route("~/V2/MResearch/M01")]
        [Route("~/V3/MResearch/{name:alpha}/M01")]
        public string M01(int? id, string name)
        {
            return "Get:M01";
        }


        //M02
        [HttpGet]
        [Route("~/V2")]
        [Route("~/V2/MResearch")]
        [Route("~/V2/MResearch/M02")]
        [Route("M02")]
        [Route("~/V3/MResearch/{name:alpha}/M02")]
        public string M02(int? id, string name)
        {
            return "Get:M02";
        }

        //M03
        [HttpGet]
        [Route("~/V3")]
        [Route("~/V3/MResearch/{name:alpha}")]
        [Route("~/V3/MResearch/{name:alpha}/M03")]
        public string M03(string name)
        {
            return "Get:M03";
        }

        //MXX
        [HttpGet]
        public string MXX()
        {
            return "MXX";
        }
    }
}