using VailaPlace.Data;
using VailaPlace.Models;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Repository
{
    public class VailaRepository : Repository<Vaila>, IVailaRepository
    {
        private readonly ApplicationDbContext _db;
        public VailaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Vaila obj)
        {
            obj.UpdatedDate = DateTime.Now;
            _db.Vailas.Update(obj);
        }
    }
}
