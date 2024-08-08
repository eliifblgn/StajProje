namespace SecKaliteDb.Models
{
    public class EnvanterStok:PrimaryEntity
    {
        public long KkdGrubuId { get; set; }
        public long KkdNiteligiId { get; set; }
        public int StokMiktari { get; set; }
        public long BirimId { get; set; }
        public virtual KkdGrubu KkdGrubu { get; set; }
        public virtual KkdNiteligi KkdNiteligi { get; set; }
        public virtual Birim Birim { get; set; }
    }
}
