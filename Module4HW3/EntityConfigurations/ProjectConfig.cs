using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities;

namespace Module4HW3.EntityConfigurations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");

            builder.HasKey(p => p.ProjectId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(o => o.StartedDate).IsRequired().HasMaxLength(7);

            builder.HasData(new List<Project>()
            {
                new Project() { ProjectId = 1, ClientId = 1, Name = "Dota", Budget = 100, StartedDate = new DateTime(2010, 01, 01) },
                new Project() { ProjectId = 2, ClientId = 2, Name = "Lol", Budget = 150, StartedDate = new DateTime(2010, 01, 01) },
                new Project() { ProjectId = 3, ClientId = 3, Name = "Valorant", Budget = 750, StartedDate = new DateTime(2010, 01, 01) },
                new Project() { ProjectId = 4, ClientId = 4, Name = "CSGO", Budget = 600, StartedDate = new DateTime(2010, 01, 01) },
                new Project() { ProjectId = 5, ClientId = 5, Name = "SpaceCleaner", Budget = 10000000, StartedDate = new DateTime(2021, 10, 10) }
            });

            builder.HasOne(c => c.Client)
                .WithMany(p => p.Project)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}