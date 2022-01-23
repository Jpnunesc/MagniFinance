using Domain.Entitys;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class CodeContext : DbContext
    {
        public CodeContext(DbContextOptions<CodeContext> options)
      : base(options)
        {
        }
        public DbSet<StudentEntity> Student { get; set; }
        public DbSet<TeacherEntity> Teacher { get; set; }
        public DbSet<SubjectEntity> Subject { get; set; }
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<GradeEntity> Grade { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new StudentMap(modelBuilder.Entity<StudentEntity>());
            new TeacherMap(modelBuilder.Entity<TeacherEntity>());
            new SubjectMap(modelBuilder.Entity<SubjectEntity>());
            new CourseMap(modelBuilder.Entity<CourseEntity>());
            new GradeMap(modelBuilder.Entity<GradeEntity>());

        }
    }
}
