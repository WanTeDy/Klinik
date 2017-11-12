using System;
using System.ComponentModel.DataAnnotations;

namespace Klinik.Frontend.Models
{
    public class PageModel
    {       
        public Int32 PageNumber { get; set; }
        public Int32 CategoryId { get; set; }
    }
}