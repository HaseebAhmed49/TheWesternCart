using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderItemHistoryConfiguration : IEntityTypeConfiguration<OrderItemHistory>
    {
        public void Configure(EntityTypeBuilder<OrderItemHistory> builder)
        {
            builder.Property(oi => oi.PriceAtPurchase)
                .HasColumnType("decimal(18,2)");
            builder.HasOne<OrderHistory>()
                .WithMany(oh => oh.OrderItems)
                .HasForeignKey(oi => oi.OrderHistoryId);
            builder.HasKey(oi => oi.Id);
        
        }
    }
}