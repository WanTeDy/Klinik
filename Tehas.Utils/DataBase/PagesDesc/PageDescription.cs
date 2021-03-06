﻿using System;
using System.Web;
using System.Collections.Generic;
using Klinik.Utils.DataBase.Security;
using Klinik.Utils.DataBase.Products;
using System.Web.Mvc;

namespace Klinik.Utils.DataBase.PagesDesc
{
    public class PageDescription : BaseObj
    {        
        /// <summary>
        /// Page's title
        /// </summary>       
        public String Title { get; set; }

        /// <summary>
        /// Page's description
        /// </summary> 
        [AllowHtml]
        public String Description { get; set; }
        /// <summary>
        /// Page's video url
        /// </summary> 
        public String VideoURL { get; set; }
        /// <summary>
        /// Page's controller name
        /// </summary> 
        public String ControllerName { get; set; }
        /// <summary>
        /// Page's action name
        /// </summary> 
        public String ActionName { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}