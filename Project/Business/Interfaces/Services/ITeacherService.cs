using Business.IO;
using Business.IO.Teacher;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ITeacherService
    {
        Task<ReturnView> Save(TeacherInput _theacher);
        Task<ReturnView> Edit(TeacherInput _theacher);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> Get(int id);
        Task<ReturnView> GetMany(TeacherFilter _filter);
    }
}
