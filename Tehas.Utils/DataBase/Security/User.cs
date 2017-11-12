using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klinik.Utils.DataBase.Security
{
    public class User : BaseObj
    {        
        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Surname { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Fathername { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Position { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Slogan { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String About { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }              
        /// <summary>
        /// TokenHash
        /// </summary>
        public String TokenHash { get; set; }            
    }
}