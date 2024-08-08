using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur!")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "TC NO zorunludur!")]
        //public string TC { get; set; }

        public bool Admin { get; set; }
    }
}
