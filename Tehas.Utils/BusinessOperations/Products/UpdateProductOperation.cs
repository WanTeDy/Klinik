using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.BusinessOperations.Products
{
    public class UpdateProductOperation : BaseOperation
    {
        private HttpPostedFileBase _image { get; set; }
        private Product _productEdit { get; set; }
        public Product _product { get; set; }

        public UpdateProductOperation(Product product, HttpPostedFileBase image)
        {
            _productEdit = product;
            _image = image;
            RussianName = "Редактирование информации продукта";
        }

        protected override void InTransaction()
        {
            _product = Context.Products.FirstOrDefault(x => x.Id == _productEdit.Id && !x.Deleted);
            if (_product == null)
                Errors.Add("Id", "Данный продукт не найден");
            else
            {
                if (_image != null)
                {
                    var url = "~/Content/images/products/";

                    var path = HttpContext.Current.Server.MapPath(url);
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
                    var deleteImg = _product.Image;
                    FileInfo fileInf = new FileInfo(path + deleteImg.FileName);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                    }
                    Context.Images.Add(image);
                    _product.Image = image;
                    Context.Images.Remove(deleteImg);
                }
                _product.Title = _productEdit.Title;
                _product.Description = _productEdit.Description;
                Context.SaveChanges();
            }
        }
    }
}