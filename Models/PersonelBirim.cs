using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class PersonelBirim : BaseEntity
    {
        [Display(Name = "Birim Adı")]
        public string BirimAdi { get; set; }
    }
}
