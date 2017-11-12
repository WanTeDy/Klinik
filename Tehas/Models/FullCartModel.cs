using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.Helpers;

namespace Klinik.Frontend.Models
{
    public class FullCartModel
    {       
        public List<CartProductsModel> Products { get; set; }
        public List<CartGamesModel> Games { get; set; }
    }
}