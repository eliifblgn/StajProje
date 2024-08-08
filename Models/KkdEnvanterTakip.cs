using System.ComponentModel.DataAnnotations;

namespace SecKaliteDb.Models
{
    public class KkdEnvanterTakip : PrimaryEntity
    {
        
        public long PersonelId { get; set; }
       
        
        public long BedenNumaraId { get; set; }
        
        
        public long? KkdNiteligiId { get; set; }

        
        public long KkdGrubuId { get; set; }

        
        public long BirimId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime TeslimTarihi { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Birim Birim { get; set; }
        public virtual BedenNumara BedenNumara { get; set; }
        public virtual KkdNiteligi KkdNiteligi { get; set; }
        public virtual KkdGrubu KkdGrubu { get; set; }
    }
}
