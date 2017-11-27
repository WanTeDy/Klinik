using System;
using System.Collections.Generic;
using Klinik.Utils.Helpers;
//using ReHouse.Utils.DataBase.ModelForUI;
//using ReHouse.Utils.DataBase.PriceRules;

namespace Klinik.Utils
{
    public static class ConstV
    {
        public const Int32 ItemsPerPage = 12;
        public const Int32 ItemsPerPageAdmin = 100;

        public const String RoleAdministrator = "Администратор";
        public static String ServerLocalPath { get; set; }
    }
}