using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class LogowanieModels
    { 

        [Required]
        public string Login { get; set; }
        [Required]
        public string Haslo { get; set; }
    }
}