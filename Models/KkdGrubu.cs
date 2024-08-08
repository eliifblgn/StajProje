using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class KkdGrubu : BaseEntity
    {
        [Display(Name = "KKD Grubu")]
        public string KkdGrubuAdi { get; set; }
        
        //public ICollection<KkdNiteligi> KkdNiteligi { get; set; }
    }
}
