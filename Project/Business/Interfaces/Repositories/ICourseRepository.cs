using Business.IO.Course;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface ICourseRepository : IRepositoryBase<CourseEntity>
    {
        Task<IEnumerable<CourseEntity>> GetFilter(CourseFilter filter);
    }
}
