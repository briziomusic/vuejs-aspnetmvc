using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuejsExamples.ViewModel;

namespace VuejsExamples.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var vm = new HomeViewModel
            {
                JumbotronTitle = "Title from view model",
                JumbotronDescription = "Description from view model",
                JumbotronButtonText = "Button from view model",
                JumbotronButtonLink = "#"
            };

            return View(vm);
        }

        [HttpGet]
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