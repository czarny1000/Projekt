using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RejestracjaModel
    {
        public class Koszyk
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Surname { get; set; }
            [Required]
            public int Pesel { get; set; }
            [Required]
            public string Department { get; set; }
            [Required]
            public string PasswordHash { get; set; }
            [Required]
            public int PhoneNumber { get; set; }
            [Required]
            public System.DateTime BirthDate { get; set; }
            [Required]
            public string UserName { get; set; }
        }
    }
}