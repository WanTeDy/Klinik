using System;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.Helpers
{
    public class CartGamesModel
    {        
        public Game Game { get; set; }        
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}