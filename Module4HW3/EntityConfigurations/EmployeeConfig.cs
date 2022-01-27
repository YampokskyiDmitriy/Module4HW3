using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).ValueGeneratedNever();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SecondName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.HiredDate).IsRequired().HasMaxLength(7);
            builder.Property(e => e.DateOfBirth).IsRequired(false);
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();

            builder.HasOne(o => o.Office)
                .WithMany(e => e.Employee)
                .HasForeignKey(o => o.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Title)
                .WithMany(e => e.Employee)
                .HasForeignKey(t => t.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Employee()
                {
                    EmployeeId = 1,
                    FirstName = "Dima",
                    SecondName = "Yampolskyi",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    HiredDate = new DateTime(2020, 1, 1),
                    OfficeId = 1,
                    TitleId = 1
                },
                new Employee()
                {
                    EmployeeId = 2,
                    FirstName = "Dima",
                    SecondName = "Yampolskyi",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    HiredDate = new DateTime(2020, 1, 1),
                    OfficeId = 2,
                    TitleId = 2
                },
                new Employee()
                {
                    EmployeeId = 3,
                    FirstName = "Dima",
                    SecondName = "Yampolskyi",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    HiredDate = new DateTime(2020, 1, 1),
                    OfficeId = 1,
                    TitleId = 2
                },
                new Employee()
                {
                    EmployeeId = 4,
                    FirstName = "Dima",
                    SecondName = "Yampolskyi",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    HiredDate = new DateTime(2020, 1, 1),
                    OfficeId = 3,
                    TitleId = 3
                },
                new Employee()
                {
                    EmployeeId = 5,
                    FirstName = "Dima",
                    SecondName = "Yampolskyi",
                    DateOfBirth = new DateTime(2001, 12, 12),
                    HiredDate = new DateTime(2020, 1, 1),
                    OfficeId = 1,
                    TitleId = 2
                });
        }
    }
}
