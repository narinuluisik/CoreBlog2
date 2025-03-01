using System.ComponentModel.DataAnnotations;

namespace CoreDeneme.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Rol adı giriniz")]
        public string name { get; set; }
    }
}
