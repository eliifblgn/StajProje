namespace SecKaliteDb.Models
{
    public class PrimaryEntity : BaseEntity
    {
        public long? OlusturanId { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }
        public long? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
    }
}
