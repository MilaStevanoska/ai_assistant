using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CareerCompass.DataContext.Entities;
using CareerCompass.DataContext.Converters;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerCompass.DataContext.Mappings
{
    public class UserExportMapping : IEntityTypeConfiguration<UserExport>
    {
        public void Configure(EntityTypeBuilder<UserExport> builder)
        {
            builder
                .ToTable("UserExport", "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.JobTitle)
                .IsRequired();

            builder
                .Property(x => x.Why)
                .IsRequired();

            builder
                .Property(x => x.SalaryRange)
                .IsRequired();

            builder
                .Property(x => x.EducationPath)
                .IsRequired();

            builder.Property(x => x.Alternatives)
                .HasConversion(new AlternativesConverter());
        }
    }
}
