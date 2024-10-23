namespace Core.Domain.Entities
{
    public class IBaseEntityTimestamps
    {
        public DateTime? LastUpdatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedDate { get; set; }
    }
}
