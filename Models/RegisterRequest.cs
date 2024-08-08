using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecKaliteDb.Models
{
    public class RegisterRequest : BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "TC No zorunludur!")]
        public string TC { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
