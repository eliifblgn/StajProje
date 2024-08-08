using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class BedenNumara : BaseEntity
    {
        [Display(Name = "Beden/Numara")]
        public string Beden {  get; set; }
       
    }
}
