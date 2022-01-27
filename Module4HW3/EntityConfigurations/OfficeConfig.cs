﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class OfficeConfig : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");

            builder.HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).ValueGeneratedNever();
            builder.Property(o => o.Title).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Location).IsRequired().HasMaxLength(100);

            builder.HasData(
               new Office()
               {
                   OfficeId = 1,
                   Title = "Office1",
                   Location = "Holodna Gora"
               },
               new Office()
               {
                   OfficeId = 2,
                   Title = "Office2",
                   Location = "Bavariya"
               },
               new Office()
               {
                   OfficeId = 3,
                   Title = "Office3",
                   Location = "Centr"
               });
        }
    }
}