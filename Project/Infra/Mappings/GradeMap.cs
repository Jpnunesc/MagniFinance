using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class GradeMap
    {
        public GradeMap(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.ToTable("Grade");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                 .HasColumnName("Id")
                 .ValueGeneratedOnAdd();

            builder.Property(t => t.FistGrade)
                  .HasColumnName("FistGrade");

            builder.Property(t => t.SecondGrade)
                   .HasColumnName("SecondGrade");

            builder.Property(t => t.ThirdGrade)
                    .HasColumnName("ThirdGrade");

            builder.Property(t => t.Fourthgrade)
                   .HasColumnName("Fourthgrade");

            builder.Property(t => t.SubjectEntityId)
                   .HasColumnName("SubjectEntityId");

            builder.Property(t => t.StudentEntityId)
                    .HasColumnName("StudentEntityId");

            builder.HasOne(x => x.Student)
                    .WithMany(c => c.Grades)
                    .HasForeignKey(x => x.StudentEntityId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                    .WithMany(c => c.Grades)
                    .HasForeignKey(x => x.SubjectEntityId)
                    .OnDelete(DeleteBehavior.Restrict);


        }

    }
}

