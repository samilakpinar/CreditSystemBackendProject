using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(x => x.StockCode)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.StockCode)
            .IsUnique();

        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.CostPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.OtherPrice)
            .HasPrecision(18, 2);

        builder.Property(x => x.CategoryId)
            .IsRequired();

        builder.Property(x => x.BrandId);
        builder.Property(x => x.ModelId);
        builder.Property(x => x.ColorId);
        builder.Property(x => x.SupplierId);

        builder.Property(x => x.VideoPath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.VideoThumbPath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.VideoStatus)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Model)
            .WithMany()
            .HasForeignKey(x => x.ModelId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate);
        builder.Property(x => x.DeletedDate);

        builder.HasIndex(x => x.DeletedDate);
    }
}
