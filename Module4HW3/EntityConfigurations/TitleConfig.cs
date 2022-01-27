using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class TitleConfig : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title");

            builder.HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).ValueGeneratedNever();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Title()
                {
                    TitleId = 1,
                    Name = "Developer"
                },
                new Title()
                {
                    TitleId = 2,
                    Name = "HR"
                },
                new Title()
                {
                    TitleId = 3,
                    Name = "TeamLead"
                });
        }
    }
}
