using Business.Interfaces.Repositories;
using Business.IO.Subject;
using Domain.Entitys;
using Infra.Context;
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
            if(filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await Task.Run(() => query.ToList());
        }
    }
}
