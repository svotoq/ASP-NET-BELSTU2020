﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Lab5b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}",
                    defaults: new { controller = "ASearch", action = "AA" }
                );

            routes.MapRoute(
                name: "Default2",
                url: "it/{fVal}/{sVal}",
                defaults: new { controller = "MResearch", action = "M03" },
                constraints: new { fVal = new FloatRouteConstraint(), sVal = new LengthRouteConstraint(2, 5) }
            );
           
        }
    }
}
