using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class EmployeeProjectConfig : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject");

            builder.HasKey(e => e.EmployeeProjectId);
            builder.Property(e => e.EmployeeProjectId).ValueGeneratedNever();
            builder.Property(e => e.Rate).IsRequired();
            builder.Property(e => e.StartedDate).IsRequired().HasMaxLength(7);
            builder.Property(e => e.EmployeeId).IsRequired();
            builder.Property(e => e.ProjectId).IsRequired();

            builder.HasOne(e => e.Employee)
                .WithMany(ep => ep.EmployeeProject)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Project)
                .WithMany(ep => ep.EmployeeProject)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new EmployeeProject()
               {
                   EmployeeProjectId = 1,
                   Rate = 1000,
                   StartedDate = new DateTime(2001, 1, 1),
                   EmployeeId = 1,
                   ProjectId = 2
               },
               new EmployeeProject()
               {
                   EmployeeProjectId = 2,
                   Rate = 1000,
                   StartedDate = new DateTime(2001, 1, 1),
                   EmployeeId = 2,
                   ProjectId = 1
               },
               new EmployeeProject()
               {
                   EmployeeProjectId = 3,
                   Rate = 1000,
                   StartedDate = new DateTime(2001, 1, 1),
                   EmployeeId = 1,
                   ProjectId = 1
               },
               new EmployeeProject()
               {
                   EmployeeProjectId = 4,
                   Rate = 1000,
                   StartedDate = new DateTime(2001, 1, 1),
                   EmployeeId = 2,
                   ProjectId = 2
               },
               new EmployeeProject()
               {
                   EmployeeProjectId = 5,
                   Rate = 1000,
                   StartedDate = new DateTime(2001, 1, 1),
                   EmployeeId = 2,
                   ProjectId = 3
               });
        }
    }
}
