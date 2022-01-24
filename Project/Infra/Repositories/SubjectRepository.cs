using Business.Interfaces.Repositories;
using Business.IO.Subject;
using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class SubjectRepository : RepositoryBase<CodeContext, SubjectEntity>, ISubjectRepository
    {
        public SubjectRepository(CodeContext context) : base(context)
        {
        }
        public async Task<IEnumerable<SubjectEntity>> GetFilter(SubjectFilter filter)
        {
            var query = DbSet as IQueryable<SubjectEntity>;
            query = query.Include(x => x.Course).AsNoTracking();
            query = query.Include(x => x.Teacher).AsNoTracking();
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await query.Select(x => new SubjectEntity 
            { 
                Id = x.Id, 
                Course = x.Course, 
                Teacher= x.Teacher,
                IdCourse = x.IdCourse,
                Status = x.Status,
                Average = x.Average,
                Name = x.Name 
            }).ToListAsync();
        }
    }
}
