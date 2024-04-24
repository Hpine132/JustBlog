using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Respository.IRespositories
{
    public interface ICategoryRepository
    {
        Category Find(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategory(int categoryId);
        IList<Category> GetAllCategories();
    }
}
