using Business.Interfaces.Repositories;
using Business.IO.Course;
using Business.IO.Grade;
using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class GradeRepository : RepositoryBase<CodeContext, GradeEntity>, IGradeRepository
    {
        public GradeRepository(CodeContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GradeEntity>> GetFilter(GradeFilter filter)
        {
            var query = DbSet as IQueryable<GradeEntity>;
            query = query.Include(x => x.Subject).ThenInclude(x => x.Teacher).AsNoTracking();
            if (filter.IdStudent.HasValue)
            {
                query = query.Where(x => x.StudentEntityId == filter.IdStudent);
            }
            if (filter.IdSubject.HasValue)
            {
                query = query.Where(x => x.SubjectEntityId == filter.IdSubject);
            }
            return await query.Select(x => new GradeEntity
            {
                Id = x.Id,
                FistGrade       = x.FistGrade,
                SecondGrade     = x.SecondGrade,
                ThirdGrade      = x.ThirdGrade,
                Fourthgrade     = x.Fourthgrade,
                StudentEntityId = x.StudentEntityId,
                SubjectEntityId = x.SubjectEntityId,
                Subject         = new SubjectEntity {
                                                      Name     =    x.Subject.Name,
                                                      Status   =    x.Subject.Status,
                                                      Average  =    x.Subject.Average, 
                                                      IdCourse =    x.Subject.IdCourse, 
                                                      Course   =    x.Subject.Course,
                                                      TeacherEntityId =    x.Subject.TeacherEntityId, 
                                                      Teacher =     x.Subject.Teacher
                                                     }
          }).ToListAsync();
        }
    }
}
