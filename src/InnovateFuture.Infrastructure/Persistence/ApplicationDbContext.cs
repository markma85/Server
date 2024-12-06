using InnovateFuture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnovateFuture.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id); // Primary Key
                entity.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(o => o.CreatedDate).IsRequired();

                // Configure one-to-many relationship between Order and OrderItems
                entity.HasMany(o => o.Items)
                    .WithOne()
                    .HasForeignKey(oi => oi.OrderId) // Use explicit foreign key
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade); // Delete Order -> Delete Items
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.Id); // Primary Key
                entity.Property(oi => oi.ProductName).IsRequired().HasMaxLength(200);
                entity.Property(oi => oi.Quantity).IsRequired();
                entity.Property(oi => oi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Ignore(oi => oi.TotalPrice); // Not mapped to DB
            });
        }
    }
}