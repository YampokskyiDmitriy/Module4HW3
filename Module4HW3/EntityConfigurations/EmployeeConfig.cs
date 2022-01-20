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
        }
    }
}
