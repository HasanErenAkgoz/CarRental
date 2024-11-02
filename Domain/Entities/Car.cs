using Core.Domain.Entities;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class Car : BaseEntity<Guid>
{
    public required Guid ModelId { get; set; }
    public required Guid FuelId { get; set; }
    public required Guid TransmissionId { get; set; }
    public required decimal DailyPrice { get; set; }
    public string? ImageUrl { get; set; }
    public required int Kilometer { get; set; }
    public required short ModelYear { get; set; }
    public required string Plate { get; set; }
    public required short MinFindexScore { get; set; }
    public required CarState CarState { get; set; }

    public virtual Model? Model { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public virtual Transmission? Transmission { get; set; }
    public ICollection<CarImage> CarImages { get; set; }
}