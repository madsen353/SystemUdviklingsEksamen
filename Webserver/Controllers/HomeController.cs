using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webserver.ObjectTypes;
using Webserver.Models;
using System.Threading.Tasks;

namespace Webserver.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public IEnumerable<ServerBasedSportsObject> sportsActivities { get; private set; }
        public async Task<ActionResult> Index()
        {
            sportsActivities = await DataFetcher.GetDataFromSkivePortalen();
            ViewBag.visualSportsActivities = sportsActivities;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}