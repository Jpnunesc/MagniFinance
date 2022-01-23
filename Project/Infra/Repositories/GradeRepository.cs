using Business.Interfaces.Repositories;
using Business.IO.Course;
using Business.IO.Grade;
using Domain.Entitys;
using Infra.Context;
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
            if(filter.IdStudent.HasValue)
            {
                query = query.Where(x => x.StudentEntityId == filter.IdStudent);
            }
            if (filter.IdSubject.HasValue)
            {
                query = query.Where(x => x.SubjectEntityId == filter.IdSubject);
            }
            return await Task.Run(() => query.ToList());
        }
    }
}
