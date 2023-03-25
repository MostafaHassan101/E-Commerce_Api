﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Configuration
{
    public class OrderConfigration
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(o => o.Quantity).IsRequired();

            builder.Property(o => o.Discount)
                .HasDefaultValue(0);
            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.ProductId).IsRequired();

        }
    }
}
