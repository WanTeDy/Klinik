using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klinik.Frontend.Areas.Cabinet.Models;
using Klinik.Frontend.Helpers;
using Klinik.Utils.BusinessOperations.Doctors;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Frontend.Areas.Cabinet.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Cabinet/Menu/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation2 = new LoadAllDoctorsOperation();
            operation2.ExcecuteTransaction();
            return View(operation2._doctors);
        }
        
        // GET: Cabinet/menu/List
        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();
            
            var operation2 = new LoadDoctorOperation(id);
            operation2.ExcecuteTransaction();
            if(operation2._doctor == null)
                return HttpNotFound();

            return View(operation2._doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Doctor model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            var op = new UpdateDoctorOperation(model, image);
            op.ExcecuteTransaction();
            if (op._doctor == null)
                return HttpNotFound();

            return View(op._doctor);
        }

        [HttpPost]
        public ActionResult Delete(int[] ids)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            DeleteDoctorsOperation op = new DeleteDoctorsOperation(ids);
            op.ExcecuteTransaction();
            
            var operation = new LoadAllDoctorsOperation();
            operation.ExcecuteTransaction();

            return PartialView("Partial/_listOfDoctorsPartial", operation._doctors);
        }

        public ActionResult Add()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Doctor model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            AddDoctorOperation op = new AddDoctorOperation(model, image);
            op.ExcecuteTransaction();

            return RedirectToAction("List");
        }
    }
}