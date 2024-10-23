using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").HasMaxLength(50).IsRequired(); ;
            builder.Property(b => b.CreatedUserID).HasColumnName("CreatedUserID").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.LastUpdatedUserID).HasColumnName("LastUpdatedUserID").IsRequired();
            builder.Property(b => b.LastUpdatedDate).HasColumnName("LastUpdatedDate").IsRequired();
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(b => b.IsDeleted).HasColumnName("IsDeleted").IsRequired();
            builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue && !b.IsDeleted);
        }
    }
}
