using FA.JustBlog.Respository.IRespositories;

namespace FA.JustBlog.Repository.Infrastructures
{
    public interface IUnitOfWork : IDisposable
      {
            public ICategoryRepository CategoryRepository { get; }
            public IPostRepository PostRepository { get; }

            int SaveChanges();
      }
}
