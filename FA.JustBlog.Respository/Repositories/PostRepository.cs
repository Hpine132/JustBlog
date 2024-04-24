using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Respository.IRespositories;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
        }

        public int CountPostsForCategory(string category)
        {
            int id = dataContext.Categories.FirstOrDefault(c => c.Name.Equals(category)).Id;
            return dataContext.Posts.Where(p => p.CategoryId == id).Count();
        }

        public int CountPostsForTag(string tag)
        {
            TagRepository c = new TagRepository();
            int id = dataContext.Tags.FirstOrDefault(c => c.Name.Equals(tag)).Id;
            return dataContext.PostTagMaps.Where(p => p.TagId == id).Count();
        }

        public void DeletePost(Post post)
        {
            dataContext.Posts.Remove(post);
        }

        public void DeletePost(int postId)
        {
            dataContext.Posts.Remove(dataContext.Posts.Find(postId));
        }

        public Post FindPost(int year, int month, string title)
        {
            return dataContext.Posts.FirstOrDefault(p => p.Title.ToLower().Contains(title.ToLower().Trim()) && p.PostedOn.Year == year && p.PostedOn.Month == month);
        }

        public Post FindPost(int postId)
        {
            return dataContext.Posts.Find(postId);
        }

        public IList<Post> GetAllPosts()
        {
            return dataContext.Set<Post>().Take(3).ToList();
        }

        public IList<Post> GetLatestPost()
        {
            return dataContext.Posts.OrderByDescending(x => x.PostedOn).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            int id = dataContext.Categories.FirstOrDefault(c => c.Name.Equals(category)).Id;
            return dataContext.Set<Post>().Where(p => p.CategoryId == id).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime month)
        {
            return dataContext.Set<Post>().Where(p => p.PostedOn.Month == month.Month && p.PostedOn.Year == month.Year).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            int id = dataContext.Tags.FirstOrDefault(c => c.Name.Equals(tag)).Id;
            return dataContext.Set<Post>().Where(p => p.PostTagMaps.Any(t => t.TagId == id)).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return dataContext.Set<Post>().Where(p => p.Published == true).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return dataContext.Set<Post>().Where(p => p.Published == false).ToList();
        }

        public void UpdatePost(Post post)
        {
            dataContext.Posts.Update(post);
        }
    }
}
