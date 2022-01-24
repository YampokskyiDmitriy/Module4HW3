using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.SecondName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DateOfBirth).IsRequired(false).HasMaxLength(50);

            builder.HasData(new List<Client>()
            {
                new Client() { ClientId = 1, FirstName = "Dima", SecondName = "Yampolskyi", Email = "yampolskyi@gmail.com", DateOfBirth = new DateTime(2000, 01, 01) },
                new Client() { ClientId = 2, FirstName = "Vadim", SecondName = "Biliy", Email = "biliy@gmail.com",  DateOfBirth = new DateTime(2000, 01, 01) },
                new Client() { ClientId = 3, FirstName = "Dima", SecondName = "Menshakov", Email = "menshakov@gmail.com", DateOfBirth = null },
                new Client() { ClientId = 4, FirstName = "Roma", SecondName = "Momot", Email = "momot@gmail.com", DateOfBirth = null },
                new Client() { ClientId = 5, FirstName = "Serezha", SecondName = "Kablukson", Email = "kablukson@gmail.com", DateOfBirth = null }
            });
        }
    }
}
