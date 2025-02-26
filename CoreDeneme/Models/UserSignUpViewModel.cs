using System.ComponentModel.DataAnnotations;

namespace CoreDeneme.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage="Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }


        [Display(Name = "şifre ")]
        [Required(ErrorMessage = "Lütfen şifre  giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar ")]
        [Compare("Password",ErrorMessage = "Şifreler uyışmuyor!   ")]
        public string ConfirmPassword { get; set; }



        [Display(Name = "Mail Adresi ")]
        [Required(ErrorMessage = "Lütfen mail  giriniz")]
        public string Mail { get; set; }



        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string UserName { get; set; }
    }

}
