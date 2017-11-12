using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Helpers;
using Klinik.Frontend.Models;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.BusinessOperations.Comments;
using Klinik.Utils.BusinessOperations.Orders;

namespace Klinik.Frontend.Controllers
{
    public class KlinikController : Controller
    {
        public ActionResult Index()
        {
            //var op = new LoadPagesDescOperation("klinik", "index");
            //op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = true;
            return View(/*op._pageDescription*/);
        }
        public ActionResult Doctor(int id)
        {
            //var op = new LoadPagesDescOperation("klinik", "index");
            //op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            return View(/*op._pageDescription*/);
        }
        public ActionResult Service()
        {
            //var op = new LoadPagesDescOperation("klinik", "index");
            //op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            return View(/*op._pageDescription*/);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult SendMessage(EmailModel mail)
        {
            var operation = new SendMailOperation(mail.Name, mail.Phone, mail.Email);
            operation.ExcecuteTransaction();
            return Json("Отправлено");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SendFeedback(Comment model)
        {
            var op = new AddCommentOperation(model);
            op.ExcecuteTransaction();
            return Json("Отправлено");
        }
    }
}