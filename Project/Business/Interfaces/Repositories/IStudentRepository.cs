using Business.IO.Student;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IStudentRepository : IRepositoryBase<StudentEntity>
    {
        Task<IEnumerable<StudentEntity>> GetFilter(StudentFilter filter);
    }
}
