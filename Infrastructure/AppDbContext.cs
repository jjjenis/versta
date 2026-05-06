using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(order => order.OrderNumber)
                .HasMaxLength(32)
                .IsRequired();

            entity.HasIndex(order => order.OrderNumber)
                .IsUnique();

            entity.Property(order => order.SenderCity)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(order => order.SenderAddress)
                .HasMaxLength(250)
                .IsRequired();

            entity.Property(order => order.RecipientCity)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(order => order.RecipientAddress)
                .HasMaxLength(250)
                .IsRequired();

            entity.Property(order => order.PickupDate);
        });
    }
}
