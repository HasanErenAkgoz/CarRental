using Core.Domain.Entities;

namespace Domain.Entities;

public class Transmission : BaseEntity<Guid>
{
    public required string Type { get; set; }
    public ICollection<Car>? Cars { get; set; }

}