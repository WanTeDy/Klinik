using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Areas.Cabinet.Models;
using Klinik.Frontend.Helpers;
using Klinik.Utils.BusinessOperations.Products;
using Klinik.Utils.BusinessOperations.Comments;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils;
using Klinik.Utils.DataBase.Emails;

namespace Klinik.Frontend.Areas.Cabinet.Controllers
{
    public class CommentController : Controller
    {
        // GET: Cabinet/Menu/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation = new LoadCommentsOperation(1, ConstV.ItemsPerPageAdmin, true);
            operation.ExcecuteTransaction();
            ViewBag.Comments = operation._comments;
            return View();
        }
       
        [HttpPost]
        public ActionResult Delete(int[] ids)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            var op = new DeleteCommentsOperation(ids);
            op.ExcecuteTransaction();

            var operation = new LoadCommentsOperation(1, ConstV.ItemsPerPageAdmin, true);
            operation.ExcecuteTransaction();

            return PartialView("Partial/_listOfCommentsPartial", operation._comments);
        }

        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();

            var operation2 = new LoadCommentOperation(id);
            operation2.ExcecuteTransaction();
            if (operation2._comment == null)
                return HttpNotFound();

            return View(operation2._comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Comment model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            var op = new UpdateCommentOperation(model, image);
            op.ExcecuteTransaction();
            if (op._comment == null)
                return HttpNotFound();

            return View(op._comment);
        }
    }
}