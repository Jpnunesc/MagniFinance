using Business.Interfaces.Repositories;
using Business.IO.Student;
using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class StudentRepository : RepositoryBase<CodeContext, StudentEntity>, IStudentRepository
    {
        public StudentRepository(CodeContext context) : base(context)
        {
        }
        public async Task<IEnumerable<StudentEntity>> GetFilter(StudentFilter filter)
        {
            var query = DbSet as IQueryable<StudentEntity>;
            query = query.Include(x => x.Course).AsNoTracking();
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await query.Select(x => new StudentEntity
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                BirthDate = x.BirthDate,
                IdCourse = x.IdCourse,
                Course = x.Course
            }).ToListAsync();
        }
    }
}
