using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Areas.Cabinet.Models;
using Klinik.Frontend.Helpers;
using Klinik.Utils.BusinessOperations.PagesDesc;
using Klinik.Utils.BusinessOperations.Games;
using Klinik.Utils.DataBase.PagesDesc;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Frontend.Areas.Cabinet.Controllers
{
    public class GameController : Controller
    {
        // GET: Cabinet/Game/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation = new LoadGamesOperation();
            operation.ExcecuteTransaction();
            return View(operation._games);
        }

        // GET: Cabinet/menu/List
        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();
            var operation = new LoadGameOperation(id);
            operation.ExcecuteTransaction();
            if(operation._game == null)
                return HttpNotFound();

            ViewBag.IsSave = false;
            return View(new GameModel { Game = operation._game });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Game model)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            var op = new UpdateGameOperation(model.Id, model.Name, model.Price, model.Description);
            op.ExcecuteTransaction();
            if (op._game == null)
                return HttpNotFound();
            ViewBag.IsSave = true;

            return View(new GameModel { Game = op._game });
        }        
    }
}