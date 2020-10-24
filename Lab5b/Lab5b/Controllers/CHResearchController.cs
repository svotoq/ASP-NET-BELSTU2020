using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab5b.Controllers
{
    [RoutePrefix("CHResearch")]
    public class CHResearchController : Controller
    {
        static int x = 0;
        [HttpGet]
        [OutputCache(Duration = 5, Location = OutputCacheLocation.Any, VaryByParam ="none")]
        public string AD()
        {
            x++;
            return "AD: x=" + x;
        }

        [HttpPost]
        [OutputCache(Duration = 7, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public string AP(string x, int y)
        {
            return "AP: x=" + x + "; y=" + y;
        }
    }
}