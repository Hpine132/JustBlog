using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Respository.IRespositories;

namespace FA.JustBlog.Core.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {
        }

        public void AddCategory(Category category)
        {
            dataContext.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            dataContext.Categories.Remove(category);
        }

        public void DeleteCategory(int categoryId)
        {
            dataContext.Categories.Remove(dataContext.Categories.Find(categoryId));
        }

        public Category Find(int categoryId)
        {
            return dataContext.Categories.Find(categoryId);
        }

        public IList<Category> GetAllCategories()
        {
            return dataContext.Set<Category>().ToList();
        }

        public void UpdateCategory(Category category)
        {
            dataContext.Categories.Update(category);
        }
    }
}
