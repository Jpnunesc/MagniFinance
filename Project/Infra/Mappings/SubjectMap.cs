using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class SubjectMap
    {
        public SubjectMap(EntityTypeBuilder<SubjectEntity> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                 .HasColumnName("Id")
                 .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Status)
                   .HasColumnName("Staus")
                    .IsRequired();

            builder.Property(t => t.IdCourse)
                    .HasColumnName("IdCourse")

                    .IsRequired();

            builder.Property(t => t.Average)
                   .HasColumnName("Average")
                    .HasMaxLength(10)
                   .IsRequired();

            builder.HasOne(x => x.Course)
                   .WithMany()
                  .HasForeignKey(x => x.IdCourse);

        }

    }
}

