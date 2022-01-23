using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class CourseMap
    {
        public CourseMap(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                 .HasColumnName("Id")
                 .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                 .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Status)
                   .HasColumnName("Status")
                   .IsRequired();

        }

    }
}

