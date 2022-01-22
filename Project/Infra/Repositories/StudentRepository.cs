using Business.Interfaces.Repositories;
using Business.IO.Student;
using Domain.Entitys;
using Infra.Context;
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
            if(filter.Status.HasValue)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            return await Task.Run(() => query.ToList());
        }
    }
}
