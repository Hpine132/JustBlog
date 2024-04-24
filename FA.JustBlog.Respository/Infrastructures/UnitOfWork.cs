
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Respository.IRespositories;

namespace FA.JustBlog.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        public UnitOfWork(JustBlogContext context = null)
        {
            _context = context ?? new JustBlogContext();
        }
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            this._context?.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
