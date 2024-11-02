using Core.Domain.Entities;

namespace Domain.Entities;

public class Model : BaseEntity<Guid>
{
    public required Guid BrandId { get; set; }
    public required string Name { get; set; }
    public virtual Brand? Brand { get; set; }
    public ICollection<Car>? Cars { get; set; }
}