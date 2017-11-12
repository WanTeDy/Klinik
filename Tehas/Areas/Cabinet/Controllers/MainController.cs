using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Helpers;
using Klinik.Utils.BusinessOperations.PagesDesc;

namespace Klinik.Frontend.Areas.Cabinet.Controllers
{
    public class MainController : Controller
    {
        // GET: Cabinet/Main
        public ActionResult Index()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            
            var operation = new LoadPagesDescOperation("home", "index");
            operation.ExcecuteTransaction();
            if (operation._pageDescription == null)
                return HttpNotFound();

            return View(operation._pageDescription);
        }
    }
}