using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class Iade : BaseEntity
    {
        public long PersonelId { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime IadeTarihi { get; set; }
        
        public virtual Personel Personel { get; set; }

        [Required]
        [Display(Name = "Envanter Durumu")]
        public EnvanterDurumu? EnvanterDurumu { get; set; }

    }
}
