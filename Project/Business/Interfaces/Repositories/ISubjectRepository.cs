using Business.IO.Subject;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface ISubjectRepository : IRepositoryBase<SubjectEntity>
    {
        Task<IEnumerable<SubjectEntity>> GetFilter(SubjectFilter filter);
    }
}
