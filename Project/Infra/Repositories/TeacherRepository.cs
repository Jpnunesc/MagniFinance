using Business.Interfaces.Repositories;
using Business.IO.Teacher;
using Domain.Entitys;
using Infra.Context;
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
            if(filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await Task.Run(() => query.ToList());
        }
    }
}
