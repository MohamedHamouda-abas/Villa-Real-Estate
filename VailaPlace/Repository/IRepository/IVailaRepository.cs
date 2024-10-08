using VailaPlace.Models;
using static VailaPlace.Repository.IRepository.IRepository;

namespace VailaPlace.Repository.IRepository
{
    public interface IVailaRepository : IRepository<Vaila>
    {
        void Update(Vaila obj);
    }
}
