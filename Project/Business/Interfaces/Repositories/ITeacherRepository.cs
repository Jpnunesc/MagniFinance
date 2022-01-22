using Business.IO.Teacher;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface ITeacherRepository : IRepositoryBase<TeacherEntity>
    {
        Task<IEnumerable<TeacherEntity>> GetFilter(TeacherFilter filter);
    }
}
