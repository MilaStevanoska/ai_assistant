using CareerCompass.DataContext.Converters;
using CareerCompass.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerCompass.DataContext.Mappings
{
    public class UserMapping
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User", "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.Salt)
                .IsRequired();

            builder
                .Property(x => x.FieldOfStudy)
                .IsRequired();

            builder
                .Property(x => x.Skills)
                .HasConversion(new SkillsConverter());

            builder
                .Property(x => x.AreasOfInterest)
                .HasConversion(new AreaOfInterestConverter());

            builder
                .Property(x => x.Goal)
                .IsRequired();
        }
    }
}
