using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class Birim : BaseEntity
    {
        [Display(Name = "Birim")]
        public string BirimAdi {  get; set; }
       
    }
}
