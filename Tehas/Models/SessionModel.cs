using System;
using Klinik.Utils.DataBase.Security;
using System.Collections.Generic;

namespace Klinik.Frontend.Models
{
    public class SessionModel
    {
        public User User { get; set; }
        public String TokenHash { get; set; }
    }
}