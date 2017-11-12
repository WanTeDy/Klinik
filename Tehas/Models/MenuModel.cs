using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.PagesDesc;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Frontend.Models
{
    public class MenuModel
    {        
        public List<Category> Categories { get; set; }        
        public List<Product> Products { get; set; }        
        public PageDescription PageDescription { get; set; }
    }
}