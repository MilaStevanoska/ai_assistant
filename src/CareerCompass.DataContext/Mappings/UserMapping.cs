using CareerCompass.DataContext.Converters;
using CareerCompass.DataContext.Entities;
using CareerCompass.DataContext.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

            var skillsComparer = new ValueComparer<IEnumerable<Skills>>(
                (a, b) => a.SequenceEqual(b),
                a => a.Aggregate(0, (h, e) => HashCode.Combine(h, e.GetHashCode())),
                a => a.ToList());

            var areasOfInterestComparer = new ValueComparer<IEnumerable<AreaOfInterest>>(
                (a, b) => a.SequenceEqual(b),
                a => a.Aggregate(0, (h, e) => HashCode.Combine(h, e.GetHashCode())),
                a => a.ToList());

            builder
                .Property(x => x.Skills)
                .HasConversion(new SkillsConverter())
                .Metadata.SetValueComparer(skillsComparer);

            builder
                .Property(x => x.AreasOfInterest)
                .HasConversion(new AreaOfInterestConverter())
                .Metadata.SetValueComparer(areasOfInterestComparer);

            builder
                .Property(x => x.Goal)
                .IsRequired();
        }
    }
}
