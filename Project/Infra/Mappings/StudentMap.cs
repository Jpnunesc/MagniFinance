using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class StudentMap
    {
        public StudentMap(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Student");
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

            builder.Property(t => t.BirthDate)
                    .HasColumnName("BirthDate")
                    .IsRequired();

            builder.Property(t => t.Registration)
                    .HasColumnName("Registration")
                    .HasMaxLength(9)
                    .IsRequired();

            builder.Property(t => t.IdCourse)
                    .HasColumnName("IdCourse")
                    .IsRequired();

            builder.HasMany(c => c.Grades)
                    .WithOne(x => x.Student)
                    .HasForeignKey(x => x.IdStudent);

        }

    }
}

