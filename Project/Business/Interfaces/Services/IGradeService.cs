using Business.IO;
using Business.IO.Grade;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IGradeService
    {
        Task<ReturnView> Save(GradeInput _course);
        Task<ReturnView> Edit(GradeInput _course);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> Get(int id);
        Task<ReturnView> GetMany(GradeFilter _filter);
    }
}
