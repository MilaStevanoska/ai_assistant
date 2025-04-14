using CareerCompass.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerCompass.DataContext.Mappings
{
    public class SchoolYearMapping
        : IEntityTypeConfiguration<SchoolYear>
    {
        public void Configure(EntityTypeBuilder<SchoolYear> builder)
        {
            builder
                .ToTable("SchoolYear", "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Year);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.SchoolYears)
                .HasForeignKey(x => x.UserId);
        }
    }
}
