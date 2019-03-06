using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VuejsExamples.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("master-detail")]
    public class MasterDetailController : Controller
    {
        private readonly List<KeyValuePair<string, string>> _province = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("Abruzzo", "Chieti"),
            new KeyValuePair<string, string>("Abruzzo", "Aquila"),
            new KeyValuePair<string, string>("Abruzzo", "Pescara"),
            new KeyValuePair<string, string>("Abruzzo", "Teramo"),

            new KeyValuePair<string, string>("Basilicata", "Matera"),
            new KeyValuePair<string, string>("Basilicata", "Potenza"),

            new KeyValuePair<string, string>("Calabria", "Catanzaro"),
            new KeyValuePair<string, string>("Calabria", "Cosenza"),
            new KeyValuePair<string, string>("Calabria", "Crotone"),
            new KeyValuePair<string, string>("Calabria", "Reggio Calabria"),
            new KeyValuePair<string, string>("Calabria", "Vibo Valentia"),


            new KeyValuePair<string, string>("Liguria", "Genova"),
            new KeyValuePair<string, string>("Liguria", "Imperia"),
            new KeyValuePair<string, string>("Liguria", "La Spezia"),
            new KeyValuePair<string, string>("Liguria", "Savona"),

            new KeyValuePair<string, string>("Sardegna", "Cagliari"),
            new KeyValuePair<string, string>("Sardegna", "Nuoro"),
            new KeyValuePair<string, string>("Sardegna", "Oristano"),
            new KeyValuePair<string, string>("Sardegna", "Sassari")
        };


        [HttpGet]
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("get-regioni")]
        [ValidateAntiForgeryToken]
        public JsonResult GetRegioni()
        {
            dynamic result = null;
            try
            {
                var distinctRegioni = _province
                  .GroupBy(p => p.Key)
                  .Select(g => g.First())
                  .ToList();

                result = new
                {
                    isSuccess = true,
                    data = distinctRegioni,
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

        [HttpPost]
        [Route("get-province")]
        [ValidateAntiForgeryToken]
        public JsonResult GetProvince(string regione)
        {
            dynamic result = null;
            try
            {
                var list = new List<KeyValuePair<string, string>>();

                if (string.IsNullOrEmpty(regione) || regione.ToUpper().Equals("TUTTE"))
                {
                    list.AddRange(_province);
                }
                else
                {
                    var temp = _province.Where(p => p.Key.ToUpper().Equals(regione.ToUpper()))
                                .ToList();

                    list.AddRange(temp);
                }

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

        [HttpGet]
        [Route("details/{regione}/{provincia}")]
        public ActionResult Details(string regione, string provincia)
        {
            var temp = "Regione: " + regione + "        " + "Provincia: " + provincia;

            return View("Details",(object)temp);
        }

    }
}