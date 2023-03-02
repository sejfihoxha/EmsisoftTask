using EmsisoftTask.Data.Entities;
using EmsisoftTask.Data.Repositories.Generics;

namespace EmsisoftTask.Data.Repositories.Hashes
{
    public interface IHashRepository : IRepository<Hash>
    {
        IQueryable<Hash> GetByDay(int dayNumber);
    }
}
