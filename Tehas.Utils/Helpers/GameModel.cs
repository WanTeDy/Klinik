using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.PagesDesc;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.Helpers
{
    public class GameModel
    {        
        public int Id { get; set; }        
        public int Quantity { get; set; }        
        public DateTime Date { get; set; }
    }
}