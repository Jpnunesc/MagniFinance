using Business.IO;
using Business.IO.Course;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ICourseService
    {
        Task<ReturnView> Save(CourseInput _course);
        Task<ReturnView> Edit(CourseInput _course);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> Get(int id);
        Task<ReturnView> GetMany(CourseFilter _filter);
    }
}
