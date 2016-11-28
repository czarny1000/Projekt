using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RejestracjaModel
    {
            public int IdUzytkownika { get; set; }
            [Required]
            public string Imie { get; set; }
            [Required]
            public string Nazwisko { get; set; }
            public Nullable<System.DateTime> Data_Urodzenia { get; set; }
            [Required]
            public string Pesel { get; set; }
            [Required]
            public string Dzial { get; set; }
            [Required]
            public Nullable<double> WyplataBrutto { get; set; }
            public Nullable<int> Uprawnienia { get; set; }
            [Required]
            public string Haslo { get; set; }
            [Required]
            [Compare("Haslo", ErrorMessage = "The password and confirmation password do not match.")]
            public string PotwierdzHaslo { get; set; }
            public Nullable<int> benefit { get; set; }
            public Nullable<int> potwierdzenie { get; set; }
            [Required]
            public string login { get; set; }
    }
}