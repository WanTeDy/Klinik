using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Frontend.Areas.Cabinet.Models
{
    public class ProductDeleteModel
    {
        public int[] ProductsId { get; set; }
        public int CategoryId { get; set; }
    }
}