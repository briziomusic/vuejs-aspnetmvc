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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult GetList(string someParameter)
        {
            dynamic result = null;
            try
            {
                List<object> list = new List<object>();

                list.Add(new {
                    title = "item #1",
                    description = "this is the description for item #1",
                    detailUrl = "#"
                });

                list.Add(new
                {
                    title = "item #2",
                    description = "this is the description for item #2",
                    detailUrl = "#"
                });

                list.Add(new
                {
                    title = "item #3",
                    description = "this item does not contains a detail url so hide the details button",
                    detailUrl = string.Empty
                });

                list.Add(new
                {
                    title = "item #4",
                    description = "this is the description for item #4",
                    detailUrl = "#"
                });

                result = new
                {
                    isSuccess = true,
                    data = list,
                    errorMessage = ""
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    isSuccess = false,
                    data = "",
                    errorMessage = ex.Message
                };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Route("client-side-sorting")]
        [HttpGet]
        public ActionResult ListSortingExample()
        {
            var list = new List<object>();

            list.Add(new
            {
                title = "TRINCIA SEMOVENTE JAGUAR 900",
                year = 2012,
                price = 85000,
            });

            list.Add(new
            {
                title = "TRANCIA CLAAS JAGUAR 900 COMPLETA DI TESTATA RU600",
                year = 2001,
                price = 42000,
            });

            list.Add(new
            {
                title = "MINIESCAVATORE CX37C CAB",
                year = 2017,
                price = 29000,
            });

            list.Add(new
            {
                title = "MINIESCAVATORE KUBOTA U35-3M3 COMPLETO DI BENNA DA SCAVO DA 700 MM E ATTACCO RAPIDO",
                year = 2017,
                price = 31000,
            });

            list.Add(new
            {
                title = "ARTICOLO SENZA PREZZO E SENZA ANNO",
            });

            return View(list);
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