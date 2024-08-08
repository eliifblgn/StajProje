using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public enum EnvanterDurumu
    {
        [Display(Name ="Stokta")]
        Stokta,
        [Display(Name = "Kişiye Zimmetli")]
        KişiyeZimmetli,
    }
}
