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
    public class AddDoctorOperation : BaseOperation
    {
        private int _categoryId { get; set; }
        private String _description { get; set; }
        private String _title { get; set; }
        private double _price { get; set; }
        private bool _isHot { get; set; }
        private HttpPostedFileBase _image { get; set; }
        private Doctor _doctor { get; set; }

        public AddDoctorOperation(Doctor doctor, HttpPostedFileBase image)
        {
            _doctor = doctor;
            _image = image;
            RussianName = "Добавление продукта";
        }

        protected override void InTransaction()
        {

            if (_image != null)
            {
                var url = "~/Content/images/doctors/";

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
                Context.Images.Add(image);
                _doctor.Image = image;
            }
            Context.Doctors.Add(_doctor);
            Context.SaveChanges();
        }
    }
}