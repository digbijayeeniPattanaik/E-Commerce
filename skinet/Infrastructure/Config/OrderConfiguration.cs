using Core.Entites.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(a => a.ShipToAdress, a => 
            { 
                a.WithOwner();
            });
            builder.Property(a => a.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            builder.HasMany(a => a.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
