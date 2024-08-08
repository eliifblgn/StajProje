using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class SifreUnuttum : BaseEntity
    {
        [Required(ErrorMessage = "TC NO zorunludur!")]
        public string TC { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
