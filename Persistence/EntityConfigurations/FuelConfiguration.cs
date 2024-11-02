using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("Fuels").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Type).HasColumnName("Type").HasMaxLength(50).IsRequired();
            builder.Property(b => b.CreatedUserID).HasColumnName("CreatedUserID").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.LastUpdatedUserID).HasColumnName("LastUpdatedUserID").IsRequired();
            builder.Property(b => b.LastUpdatedDate).HasColumnName("LastUpdatedDate").IsRequired();
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(b => b.IsDeleted).HasColumnName("IsDeleted").IsRequired();
            builder.Property(b => b.Status).HasColumnName("Status").IsRequired();
            builder.HasIndex(indexExpression: b => b.Type).IsUnique();
            builder.HasMany(f => f.Cars).WithOne(c => c.Fuel).HasForeignKey(c => c.FuelId);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue && !b.IsDeleted);

        }
    }
}