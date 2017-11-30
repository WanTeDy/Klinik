using System;
using System.Collections.Generic;
using Klinik.Utils.DataBase.Security;
using Klinik.Utils.DataBase.Products;

namespace Klinik.Utils.DataBase.Emails
{
    public class Comment : BaseObj
    {
        /// <summary>
        /// user's name
        /// </summary>       
        public String Username { get; set; }
        /// <summary>
        /// user's name
        /// </summary>       
        public String Company { get; set; }
        /// <summary>
        /// Message
        /// </summary> 
        public String Message { get; set; }
        /// <summary>
        /// datetime
        /// </summary> 
        public DateTime Date { get; set; }
        /// <summary>
        /// Is comment past moderation
        /// </summary> 
        public Boolean IsModerated { get; set; }

        public virtual Image Image { get; set; }
    }
}