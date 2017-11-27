using Klinik.Utils.DataBase.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Klinik.Utils.DataBase.Security
{
    public class Doctor : BaseObj
    {
        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Surname
        /// </summary>
        public String Surname { get; set; }
        /// <summary>
        /// FatherName
        /// </summary>
        public String FatherName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public String Position { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public String Slogan { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public Int32 OrderNum { get; set; }
        /// <summary>
        /// TokenHash
        /// </summary>
        [AllowHtml]
        public String Description { get; set; }
        [NotMapped]
        public String ShortName
        {
            get
            {
                var name = Name ?? String.Empty;
                var fathername = FatherName ?? String.Empty;
                return Surname + " " + name[0] + "." + fathername[0] + ".";
            }
            set { }
        }

        public virtual Image Image { get; set; }
    }
}