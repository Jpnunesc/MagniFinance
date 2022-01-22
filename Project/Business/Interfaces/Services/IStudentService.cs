using Business.IO;
using Business.IO.Student;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IStudentService
    {
        Task<ReturnView> Save(StudentInput _student);
        Task<ReturnView> Edit(StudentInput _student);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> Get(int id);
        Task<ReturnView> GetMany(StudentFilter _filter);
    }
}
