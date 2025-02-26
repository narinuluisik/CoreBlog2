using System.ComponentModel.DataAnnotations;

namespace CoreDeneme.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifre  giriniz")]
        public string password { get; set; }
    }
}
