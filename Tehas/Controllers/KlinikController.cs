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
using Klinik.Utils.BusinessOperations;
using Klinik.Utils.BusinessOperations.Users;

namespace Klinik.Frontend.Controllers
{
    public class KlinikController : Controller
    {
        private static Dictionary<string, int> ServiceIds { get; set; }

        public ActionResult Index()
        {
            var op = new LoadAllDoctorsOperation();
            op.ExcecuteTransaction();
            ViewBag.Doctors = op._doctors;
            var op2 = new LoadAllProductsOperation();
            op2.ExcecuteTransaction();
            ViewBag.Products = op2._products;
            var op3 = new LoadCommentsOperation(1, 4);
            op3.ExcecuteTransaction();
            ViewBag.Comments = op3._comments;
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

        public ActionResult Service(int id)
        {
            if (id <= 0)
                return HttpNotFound();

            var op = new LoadAllProductsOperation();
            op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            var service = op._products.FirstOrDefault(x => x.Id == id);
            if (service == null)
                return HttpNotFound();

            return RedirectToRoute(service.Tag);
        }

        [Route("{serviceName}")]
        public ActionResult Service(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
                return HttpNotFound();

            var op = new LoadAllProductsOperation();
            op.ExcecuteTransaction();
            ViewBag.NavMenuEnabled = false;
            var service = op._products.FirstOrDefault(x => x.Tag == serviceName.ToLower());
            if (service == null)
                return HttpNotFound();

            ViewBag.Selected = service;
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