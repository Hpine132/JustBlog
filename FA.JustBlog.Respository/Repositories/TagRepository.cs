using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Respository.IRespositories;

namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext db;

        public TagRepository()
        {
            db = new JustBlogContext();
        }

        public void AddTag(Tag Tag)
        {
            db.Tags.Add(Tag);
            db.SaveChanges();
        }

        public void DeleteTag(Tag Tag)
        {
            db.Tags.Remove(Tag);
            db.SaveChanges();
        }

        public void DeleteTag(int TagId)
        {
            db.Tags.Remove(db.Tags.Find(TagId));
            db.SaveChanges();
        }

        public Tag Find(int TagId)
        {
            return db.Tags.Find(TagId);
        }

        public IList<Tag> GetAllTags()
        {
            return db.Set<Tag>().ToList();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return db.Tags.FirstOrDefault(t => t.UrlSlug.Equals(urlSlug));
        }

        public void UpdateTag(Tag Tag)
        {
            db.Tags.Update(Tag);
            db.SaveChanges();
        }
    }
}
