using Domain.Entitys;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

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

            modelBuilder.Entity<CourseEntity>().HasData(
               new CourseEntity
               {
                   Id = 1,
                   Name = "Information systems",
                   Status = true
               });


            modelBuilder.Entity<TeacherEntity>().HasData(
                 new TeacherEntity
                 {
                     Id = 1,
                     Name = "João Paulo Costa",
                     Remuneration = 20000,
                     BirthDate = new DateTime(new DateTime(1994, 03, 08, 00, 00, 0, new CultureInfo("en-US", false).Calendar).Ticks),
                     Status = true
                 },
                 new TeacherEntity
                 {
                     Id = 2,
                     Name = "Paulo Henrique",
                     Remuneration = 25000,
                     BirthDate = new DateTime(new DateTime(1993, 06, 08, 00, 00, 0, new CultureInfo("en-US", false).Calendar).Ticks),
                     Status = true
                 }
                 );

            modelBuilder.Entity<SubjectEntity>().HasData(
                 new SubjectEntity
                 {
                     Id = 1,
                     IdCourse = 1,
                     Average = 8,
                     Name = "Eng. Software",
                     TeacherEntityId = 1,
                     Status = true
                 },
                 new SubjectEntity
                 {
                     Id = 2,
                     IdCourse = 1,
                     Average = 8,
                     Name = "Mathematics",
                     TeacherEntityId = 1,
                     Status = true
                 },
                 new SubjectEntity
                 {
                     Id = 3,
                     IdCourse = 1,
                     Average = 8,
                     Name = "Architecture",
                     TeacherEntityId = 1,
                     Status = true
                 },
                 new SubjectEntity
                 {
                     Id = 4,
                     IdCourse = 1,
                     Average = 8,
                     Name = "Banco de dados",
                     TeacherEntityId = 2,
                     Status = true
                 }

                 );

            modelBuilder.Entity<StudentEntity>().HasData(
                 new StudentEntity
                 {
                     Id = 1,
                     Name = "Pedro Luciano",
                     Status = true,
                     BirthDate = new DateTime(new DateTime(1998, 05, 08, 00, 00, 0, new CultureInfo("en-US", false).Calendar).Ticks),
                     IdCourse = 1
                 });

            modelBuilder.Entity<GradeEntity>().HasData(
                 new GradeEntity
                 {
                     Id = 1,
                     StudentEntityId = 1,
                     SubjectEntityId = 1,
                     FistGrade = 7,
                     SecondGrade = 8,
                     ThirdGrade = 9,
                     Fourthgrade = 9
                 });
        }
    }
}
