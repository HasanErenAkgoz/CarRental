using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(b => b.FuelId).HasColumnName("FuelId").IsRequired();
            builder.Property(b => b.TransmissionId).HasColumnName("TransmissionId").IsRequired();
            builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
            builder.Property(b => b.ModelYear).HasColumnName("ModelYear").IsRequired();
            builder.Property(b => b.Plate).HasColumnName("Plate").HasMaxLength(20).IsRequired();
            builder.Property(b => b.MinFindexScore).HasColumnName("MinFindexScore").IsRequired();
            builder.Property(b => b.CarState).HasColumnName("CarState").IsRequired();
            builder.Property(b => b.DailyPrice).HasColumnName("DailyPrice").IsRequired();
            builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl");

            builder.HasOne(b => b.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(b => b.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Fuel)
                .WithMany(f => f.Cars)
                .HasForeignKey(b => b.FuelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Transmission)
                .WithMany(t => t.Cars)
                .HasForeignKey(b => b.TransmissionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue && !b.IsDeleted);

        }
    }
}