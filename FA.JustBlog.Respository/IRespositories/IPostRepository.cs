using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Respository.IRespositories
{
    public interface IPostRepository
    {
        Post FindPost(int year, int month, string urlSlug);
        Post FindPost(int postId);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        void DeletePost(int postId);
        IList<Post> GetAllPosts();
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost();
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
    }
}
