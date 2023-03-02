using EmsisoftTask.Data.Entities;
using EmsisoftTask.Data.Repositories.Hashes;
using EmsisoftTask.Services.Models.Hashes;
using EmsisoftTask.Services.RabitMQ;
using System.Security.Cryptography;

namespace EmsisoftTask.Services.Services.Hashes
{
    public class HashService : IHashService
    {
        private readonly IHashRepository _hashRepository;
        private readonly IRabitMQProducer _rabitMQProducer;

        public HashService(IHashRepository hashRepository, IRabitMQProducer rabitMQProducer)
        {
            _hashRepository = hashRepository;
            _rabitMQProducer = rabitMQProducer;
        }
        public IList<HashModel> GetByDay(int dayNumber)
        {
            var hashes = _hashRepository.GetByDay(dayNumber);

            return hashes.GroupBy(x => x.InsertDate.Date)
                         .Select(g => new HashModel()
                         {
                             DateTime = g.Key,
                             Count = g.Count(),
                         }).ToList();
        }

        public void GenerateRandomSHA1Hashes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Generate a random byte array
                byte[] randomBytes = new byte[16];

                // Compute the SHA1 hash of the random bytes
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hashBytes = sha1.ComputeHash(randomBytes);

                    // Convert the hash to a string representation
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "");

                    var hash = new Hash()
                    {
                        Sha1 = hashString,
                        InsertDate = DateTime.Now,
                    };

                    _rabitMQProducer.SendProductMessage(hash);
                }
            }
        }
    }
}
