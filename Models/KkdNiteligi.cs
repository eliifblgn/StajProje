using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class KkdNiteligi : BaseEntity
    {
        [Display(Name = "KKD Niteliği")]
        public string KkdNiteligiAdi { get; set; }

        public long KkdGrubuId { get; set; }

        public virtual KkdGrubu KkdGrubu { get; set; }
    }
}
