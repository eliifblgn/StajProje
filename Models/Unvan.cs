using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class Unvan : BaseEntity
    {
        [Display(Name = "Unvan Adı")]
        public string UnvanAdi { get; set; }
    }
}
