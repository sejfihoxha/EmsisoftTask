namespace EmsisoftTask.Data.Repositories.Generics
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Tentity Add(Tentity entity);
        List<Tentity> AddRange(List<Tentity> entities);
        Task<IList<Tentity>> GetAllAsync();

    }
}
