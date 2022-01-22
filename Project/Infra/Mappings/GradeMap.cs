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

            builder.Property(t => t.StudentGrade)
                .HasColumnName("StudentGrade");

            builder.Property(t => t.IdStudent)
                   .HasColumnName("IdStudent")
                    .IsRequired();

            builder.Property(t => t.IdSubject)
                    .HasColumnName("IdSubject")
                    .IsRequired();

            builder.HasOne(x => x.Student)
                    .WithMany()
                    .HasForeignKey(x => x.IdStudent);

            builder.HasOne(x => x.Subject)
                    .WithMany()
                    .HasForeignKey(x => x.IdSubject);
        }

    }
}

