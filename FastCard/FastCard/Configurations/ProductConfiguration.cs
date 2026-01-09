using FastCard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCard.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint(
                    "CK_Products_Price_Positive",
                    "Price > 0"
                );

                tableBuilder.HasCheckConstraint(
                    "CK_Products_Stock_NonNegative",
                    "Stock >= 0"
                );
            });

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.Property(p => p.Price)
                   .IsRequired();

            builder.Property(p => p.Stock)
                   .IsRequired();

            builder.HasIndex(p => p.Name);
        }
    }
}
