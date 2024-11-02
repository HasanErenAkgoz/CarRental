using Core.Domain.Entities;

namespace Domain.Entities;

public class CarImage : BaseEntity<Guid>
{
    public int Id { get; set; }
    public Guid CarId { get; set; }
    public virtual Car Car { get; set; }
    public required string ImagePath { get; set; }
}