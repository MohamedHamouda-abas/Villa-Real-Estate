using VailaPlace.Data;
using VailaPlace.Models;
using VailaPlace.Repository.IRepository;

namespace VailaPlace.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVailaRepository VailaRepository { get; private set; }
        public IVailaNumberRepository VailaNumberRepository { get; private set; }



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            VailaRepository = new VailaRepository(db);
            VailaNumberRepository=new VailaNumberRepository(db);
          
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
