using InnovateFuture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnovateFuture.Infrastructure.Persistence.ModelConfigs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id); // Primary Key
        builder.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
        builder.Property(o => o.CreatedDate).IsRequired();

        // Configure one-to-many relationship between Order and OrderItems
        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId) // Use explicit foreign key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Delete Order -> Delete Items
    }
}
