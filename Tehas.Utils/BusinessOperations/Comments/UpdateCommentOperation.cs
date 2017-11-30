using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Security;
using Klinik.Utils.DataBase.Emails;

namespace Klinik.Utils.BusinessOperations.Comments
{
    public class UpdateCommentOperation : BaseOperation
    {
        private HttpPostedFileBase _image { get; set; }
        private Comment comment { get; set; }
        public Comment _comment { get; set; }

        public UpdateCommentOperation(Comment comment, HttpPostedFileBase image)
        {
            this.comment = comment;
            _image = image;
            RussianName = "Редактирование информации продукта";
        }

        protected override void InTransaction()
        {
            _comment = Context.Comments.FirstOrDefault(x => x.Id == comment.Id && !x.Deleted);
            if (_comment == null)
                Errors.Add("Id", "Данный продукт не найден");
            else
            {
                if (_image != null)
                {
                    var url = "~/Content/images/comments/";

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
                    var deleteImg = _comment.Image;
                    FileInfo fileInf = new FileInfo(path + deleteImg.FileName);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                    }
                    Context.Images.Add(image);
                    _comment.Image = image;
                    Context.Images.Remove(deleteImg);
                }
                _comment.Company = comment.Company;
                _comment.Username = comment.Username;
                _comment.Message = comment.Message;
                _comment.IsModerated = comment.IsModerated;
                Context.SaveChanges();
            }
        }
    }
}