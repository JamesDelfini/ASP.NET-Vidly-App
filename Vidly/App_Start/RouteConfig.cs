using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Convention-Based Routes (Custom Routes)
            // Example /movies/released/2015/04
            // Old Convention of Custom Routes
            /* routes.MapRoute(
               "MoviesReleaseDate",
                "movies/released/{year}/{month}",
                new {controller = "Movies", action = "ByReleaseDate"},
                new { year = @"2015|2016", month = @"\d{2}"} // Validating URL; e.g. year = @"\d{4}"
            );*/

            // New Conventation of Custom Routes
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
