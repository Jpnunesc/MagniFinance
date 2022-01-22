using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    [DbContext(typeof(Context.CodeContext))]
    public class TeacherMap
    {
        public TeacherMap(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.ToTable("Teacher");
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

            builder.Property(t => t.Remuneration)
                   .HasColumnName("Remuneration")
                   .IsRequired();

            builder.Property(t => t.IdSubject)
                    .HasColumnName("IdSubject")
                    .IsRequired();

            builder.HasOne(x => x.Subject)
                   .WithMany()
                   .HasForeignKey(x => x.IdSubject);
        }

    }
}

