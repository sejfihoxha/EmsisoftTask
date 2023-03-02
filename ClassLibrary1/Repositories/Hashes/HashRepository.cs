using EmsisoftTask.Data.Entities;
using EmsisoftTask.Data.EntityFramework;
using EmsisoftTask.Data.Repositories.Generics;

namespace EmsisoftTask.Data.Repositories.Hashes
{
    public class HashRepository : Repository<Hash>, IHashRepository
    {
        public HashRepository(EmsisoftTaskDbContext contex) : base(contex)
        {

        }

        public IQueryable<Hash> GetByDay(int dayNumber)
        {
            return DbSet.Take(dayNumber).AsQueryable();
        }
    }
}
