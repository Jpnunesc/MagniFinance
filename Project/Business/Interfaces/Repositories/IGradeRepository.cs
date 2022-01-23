using Business.IO.Grade;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IGradeRepository : IRepositoryBase<GradeEntity>
    {
        Task<IEnumerable<GradeEntity>> GetFilter(GradeFilter filter);
    }
}
