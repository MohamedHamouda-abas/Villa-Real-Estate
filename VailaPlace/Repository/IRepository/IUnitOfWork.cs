namespace VailaPlace.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IVailaRepository VailaRepository { get; }
        IVailaNumberRepository VailaNumberRepository { get; }

        public void Save();
    }
}
