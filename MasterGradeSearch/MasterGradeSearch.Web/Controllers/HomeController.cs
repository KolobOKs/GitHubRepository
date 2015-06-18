using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterGradeSearch.Web.Controllers
{
    /// <summary>
    ///     "Домашний" контроллер. Первый контроллер, на который попадает пользоватль
    ///     У тебя его нет, сразу происходит переадресация на контроллер поиска
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // ПЕРЕАДРЕСАЦИЯ ПРОИСХОДИТ ЗДЕСЬ
            return RedirectPermanent("./Search");
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