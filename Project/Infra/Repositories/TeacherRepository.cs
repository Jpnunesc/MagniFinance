using Business.Interfaces.Repositories;
using Business.IO.Teacher;
using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class TeacherRepository : RepositoryBase<CodeContext, TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(CodeContext context) : base(context)
        {
        }
        public async Task<IEnumerable<TeacherEntity>> GetFilter(TeacherFilter filter)
        {
            var query = DbSet as IQueryable<TeacherEntity>;
            query = query.Include(x => x.Subjects).AsNoTracking();
            if(filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await query.Select(x => new TeacherEntity
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                BirthDate = x.BirthDate,
                Remuneration = x.Remuneration
            }).ToListAsync();
        }
    }
}
