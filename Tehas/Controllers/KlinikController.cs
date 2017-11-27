using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Helpers;
using Klinik.Frontend.Models;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.BusinessOperations.Comments;
using Klinik.Utils.BusinessOperations.Orders;
using Klinik.Utils.BusinessOperations.Doctors;
using Klinik.Utils.BusinessOperations.Products;

namespace Klinik.Frontend.Controllers
{
    public class KlinikController : Controller
    {
        public ActionResult Index()
        {
            var op = new LoadAllDoctorsOperation();
            op.ExcecuteTransaction();
            ViewBag.Doctors = op._doctors;
            var op2 = new LoadAllProductsOperation();
            op2.ExcecuteTransaction();
            ViewBag.Products = op2._products;
            ViewBag.NavMenuEnabled = true;
            return View(/*op._pageDescription*/);
        }
        public ActionResult Doctor(int id)
        {
            var op = new LoadDoctorOperation(id);
            op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            return View(op._doctor);
        }
        public ActionResult Service(int? id)
        {
            var op = new LoadAllProductsOperation();
            op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            ViewBag.Selected = op._products.FirstOrDefault(x => x.Id == id.GetValueOrDefault()) ?? op._products.FirstOrDefault();
            return View(op._products);
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