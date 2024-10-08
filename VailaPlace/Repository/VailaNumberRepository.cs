using VailaPlace.Data;
using VailaPlace.Models;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Repository
{
    public class VailaNumberRepository : Repository<VailaNumber>, IVailaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VailaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(VailaNumber obj)
        {
            obj.UpdatedDate = DateTime.Now;
            _db.VailaNumbers.Update(obj);
        }
    }
}
