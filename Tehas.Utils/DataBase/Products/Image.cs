using System;
using System.Collections.Generic;
using Klinik.Utils.DataBase.PagesDesc;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Utils.DataBase.Products
{
    public class Image : BaseObj
    {
        /// <summary>
        /// FileName of image
        /// </summary>
        public String FileName { get; set; }
        /// <summary>
        /// Url of image
        /// </summary>
        public String Url { get; set; }
        /// <summary>
        /// Description of image
        /// </summary>
        public String Description { get; set; }

        public virtual List<PageDescription> PageDescriptions { get; set; }
    }
}