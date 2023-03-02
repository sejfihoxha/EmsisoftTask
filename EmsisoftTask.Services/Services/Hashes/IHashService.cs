using EmsisoftTask.Services.Models.Hashes;

namespace EmsisoftTask.Services.Services.Hashes
{
    public interface IHashService
    {
        void GenerateRandomSHA1Hashes(int count);
        IList<HashModel> GetByDay(int dayNumber);

    }
}
