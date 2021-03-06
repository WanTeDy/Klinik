﻿//using System;
//using System.Web;
//using System.Collections.Generic;
//using System.Linq;
//using Klinik.Utils.DataBase.Products;
//using ImageResizer;

//namespace Klinik.Utils.BusinessOperations.PagesDesc
//{
//    public class AddPagesDescOperation : BaseOperation
//    {
//        private String _controller { get; set; }
//        private String _action { get; set; }
//        private String _description { get; set; }
//        private String _title { get; set; }
//        private String _videoUrl { get; set; }
//        private IEnumerable<HttpPostedFileBase> _images { get; set; }
//        public PageDescription _pageDescription { get; set; }

//        public AddPagesDescOperation(string controller, string action, string description, string title, string videoUrl, IEnumerable<HttpPostedFileBase> images)
//        {
//            _controller = controller.ToLower();
//            _action = action.ToLower();
//            _description = description;
//            _title = title;
//            _videoUrl = videoUrl;
//            _images = images;
//            RussianName = "Добавление информации о новой странице";
//        }

//        protected override void InTransaction()
//        {
//            List<Image> images = new List<Image>();

//            var exists = Context.PageDescriptions.FirstOrDefault(x => x.ControllerName == _controller && x.ActionName == _action && !x.Deleted);
//            if (exists != null)
//            {
//                Errors.Add("ActionName", "Страница с таким адресом уже существует!");
//            }
//            else
//            {
//                if (_images != null)
//                {
//                    foreach (var imageFile in _images)
//                    {
//                        if (imageFile != null)
//                        {
//                            var url = String.Format("~/Content/images/pages/{0}/{1}/", _controller, _action);

//                            var path = HttpContext.Current.Server.MapPath(url);
//                            imageFile.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
//                            int point = imageFile.FileName.LastIndexOf('.');                            
//                            var filename = imageFile.FileName.Substring(0, point) + "_" + DateTime.Now.ToFileTime();

//                            ImageBuilder.Current.Build(
//                                new ImageJob(imageFile.InputStream,
//                                path + filename,
//                                new Instructions("maxwidth=1600&maxheight=1200&format=jpg&quality=80"),
//                                false,
//                                true));

//                            var image = new Image
//                            {
//                                FileName = filename + ".jpg",
//                                Url = url,
//                            };
//                            Context.Images.Add(image);
//                            images.Add(image);
//                        }
//                    }
//                }
//                PageDescription page = new PageDescription
//                {
//                    ActionName = _action,
//                    ControllerName = _controller,
//                    Description = _description,
//                    Title = _title,
//                    VideoURL = _videoUrl,
//                    Images = images,
//                };
//                Context.PageDescriptions.Add(page);
//                Context.SaveChanges();
//            }
//        }
//    }
//}