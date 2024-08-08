using System.ComponentModel.DataAnnotations;
namespace SecKaliteDb.Models 

{
    public class Personel : BaseEntity
    {
        [Display(Name = "Adı")]
        [Required(ErrorMessage = "Adı alanı zorunludur.")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyadı alanı zorunludur.")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Sicil No alanı zorunludur.")]
        public string SicilNo { get; set; }

        [Required(ErrorMessage = "Birim seçimi zorunludur.")]
        public long? PersonelBirimId { get; set; }

        [Required(ErrorMessage = "Unvan seçimi zorunludur.")]
        public long UnvanId { get; set; }
        
        public long KkdEnvanterTakipId { get; set; }

        [Display(Name = "Adı Soyadı")]
        public string AdSoyad => $"{Adi} {Soyadi}";

        public virtual PersonelBirim PersonelBirim { get; set; }
        
        public virtual Unvan Unvan { get; set; }
        
        public ICollection<KkdEnvanterTakip> KkdEnvanterTakip { get; set; }
        public ICollection<Teslimat> Teslimat { get; set; }

    }
}
