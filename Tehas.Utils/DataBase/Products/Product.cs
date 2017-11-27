using System;
using System.Collections.Generic;
using Klinik.Utils.DataBase.Security;
using Klinik.Utils.Helpers;

namespace Klinik.Utils.DataBase.Products
{
    public class Product : BaseObj
    {        
        /// <summary>
        /// Title's name for this product
        /// </summary>
        public String Title { get; set; }        
        /// <summary>
        /// Discription for this product
        /// </summary>
        public String Description { get; set; }

        //public virtual Category Category { get; set; }        
        public virtual Image Image { get; set; }
    }
}