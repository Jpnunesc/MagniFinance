using Business.IO;
using Business.IO.Subject;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<ReturnView> Save(SubjectInput _student);
        Task<ReturnView> Edit(SubjectInput _student);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> Get(int id);
        Task<ReturnView> GetMany(SubjectFilter _filter);
    }
}
