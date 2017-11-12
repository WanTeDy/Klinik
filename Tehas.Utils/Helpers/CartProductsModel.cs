using System;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.Helpers
{
    public class CartProductsModel
    {        
        public Product Product { get; set; }        
        public int Quantity { get; set; }
    }
}