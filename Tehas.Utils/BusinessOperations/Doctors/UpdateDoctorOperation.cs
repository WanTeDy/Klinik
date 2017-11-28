using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Utils.BusinessOperations.Doctors
{
    public class UpdateDoctorOperation : BaseOperation
    {
        private HttpPostedFileBase _image { get; set; }
        private Doctor _doctorEdit { get; set; }
        public Doctor _doctor { get; set; }

        public UpdateDoctorOperation(Doctor doctor, HttpPostedFileBase image)
        {
            _doctorEdit = doctor;
            _image = image;
            RussianName = "Редактирование информации продукта";
        }

        protected override void InTransaction()
        {
            _doctor = Context.Doctors.FirstOrDefault(x => x.Id == _doctorEdit.Id && !x.Deleted);
            if (_doctor == null)
                Errors.Add("Id", "Данный продукт не найден");
            else
            {
                if (_image != null)
                {
                    var url = "~/Content/images/products/";

                    var path = HttpContext.Current.Server.MapPath(url);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    _image.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
                    int point = _image.FileName.LastIndexOf('.');
                    var filename = _image.FileName.Substring(0, point) + "_" + DateTime.Now.ToFileTime();

                    ImageBuilder.Current.Build(
                        new ImageJob(_image.InputStream,
                        path + filename,
                        new Instructions("maxwidth=1200&maxheight=1200&format=jpg&quality=80"),
                        false,
                        true));

                    var image = new Image
                    {
                        FileName = filename + ".jpg",
                        Url = url,
                    };
                    var deleteImg = _doctor.Image;
                    FileInfo fileInf = new FileInfo(path + deleteImg.FileName);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                    }
                    Context.Images.Add(image);
                    _doctor.Image = image;
                    Context.Images.Remove(deleteImg);
                }
                _doctor.Name = _doctorEdit.Name;
                _doctor.Surname = _doctorEdit.Surname;
                _doctor.Position = _doctorEdit.Position;
                _doctor.OrderNum = _doctorEdit.OrderNum;
                _doctor.Slogan = _doctorEdit.Slogan;
                _doctor.FatherName = _doctorEdit.FatherName;
                _doctor.Description = _doctorEdit.Description;
                Context.SaveChanges();
            }
        }
    }
}