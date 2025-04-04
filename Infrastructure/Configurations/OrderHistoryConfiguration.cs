using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Enums;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.Status)
                .HasConversion(
                    s => s.ToString(),
                    s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s)
                );
            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderHistoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.User)
                .WithMany(u => u.OrderHistories)
                .HasForeignKey(o => o.UserId);
        }        
    }
}