using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.Helpers;

namespace Klinik.Utils.Models
{
    public class FullCartModel
    {       
        public UserEmailMessage Email { get; set; }
        public List<CartProductsModel> Products { get; set; }
        public List<CartGamesModel> Games { get; set; }
    }
}