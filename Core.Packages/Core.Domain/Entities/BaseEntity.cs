namespace Core.Domain.Entities
{
    public class BaseEntity<TId> : IBaseEntityTimestamps
    {
        public TId Id { get; set; }
        public int CreatedUserID { get; set; } = 1;
        public int LastUpdatedUserID { get; set; } = 1;
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
