using System;
using System.Collections.Generic;

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
    }
}