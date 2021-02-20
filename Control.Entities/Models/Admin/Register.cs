using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Entities.Models.Admin
{
    public class Register
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string NameLastname { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        public string RespondTitle { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        public string Birthdate { get; set; }

        [Required]
        [Display(Name = "Cinsiyet")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Başlama Tarihi")]
        public string HireDate { get; set; }

        [Required]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }        

        [Required]
        [Display(Name = "Yaşadığınız Ülke")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Yaşadığınız Şehir")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]

        public string ConfirmPassword { get; set; }
    }
}
