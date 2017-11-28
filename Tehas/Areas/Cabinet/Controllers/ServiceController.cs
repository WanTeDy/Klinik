using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Areas.Cabinet.Models;
using Klinik.Frontend.Helpers;
using Klinik.Utils.BusinessOperations.Products;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Frontend.Areas.Cabinet.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Cabinet/Menu/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation2 = new LoadAllProductsOperation();
            operation2.ExcecuteTransaction();
            return View(operation2._products);
        }
        
        // GET: Cabinet/menu/List
        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();
            
            var operation2 = new LoadProductOperation(id);
            operation2.ExcecuteTransaction();
            if(operation2._product == null)
                return HttpNotFound();

            return View(operation2._product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Product model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            UpdateProductOperation op = new UpdateProductOperation(model, image);
            op.ExcecuteTransaction();
            if (op._product == null)
                return HttpNotFound();

            return View(op._product);
        }

        [HttpPost]
        public ActionResult Delete(int[] ids)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            DeleteProductsOperation op = new DeleteProductsOperation(ids);
            op.ExcecuteTransaction();
            
            var operation = new LoadAllProductsOperation();
            operation.ExcecuteTransaction();

            return PartialView("Partial/_listOfProductsPartial", operation._products);
        }

        public ActionResult Add()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            AddProductOperation op = new AddProductOperation(model, image);
            op.ExcecuteTransaction();

            return RedirectToAction("List");
        }
    }
}