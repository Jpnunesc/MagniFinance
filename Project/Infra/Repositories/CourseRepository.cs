using Business.Interfaces.Repositories;
using Business.IO.Course;
using Domain.Entitys;
using Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CourseRepository : RepositoryBase<CodeContext, CourseEntity>, ICourseRepository
    {
        public CourseRepository(CodeContext context) : base(context)
        {
        }
        public async Task<IEnumerable<CourseEntity>> GetFilter(CourseFilter filter)
        {
            var query = DbSet as IQueryable<CourseEntity>;
            if(filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await Task.Run(() => query.ToList());
        }
    }
}
