using VailaPlace.Models;
using static VailaPlace.Repository.IRepository.IRepository;

namespace VailaPlace.Repository.IRepository
{
    public interface IVailaNumberRepository : IRepository<VailaNumber>
    {
        void Update(VailaNumber obj);
    }
}
