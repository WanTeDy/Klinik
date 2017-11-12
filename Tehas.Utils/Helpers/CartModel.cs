using System;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.Helpers
{
    public class CartModel
    {        
        public int Id { get; set; }        
        public int Quantity { get; set; }
    }
}