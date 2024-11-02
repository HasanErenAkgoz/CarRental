using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

        builder.Property(b => b.CreatedUserID).HasColumnName("CreatedUserID").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.LastUpdatedUserID).HasColumnName("LastUpdatedUserID").IsRequired();
        builder.Property(b => b.LastUpdatedDate).HasColumnName("LastUpdatedDate").IsRequired();
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(b => b.IsDeleted).HasColumnName("IsDeleted").IsRequired();
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();
        builder.HasMany(b => b.Cars).WithOne(b => b.Model).HasForeignKey(b => b.ModelId);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue && !b.IsDeleted);
    }
}