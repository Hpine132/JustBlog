using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Respository.IRespositories
{
    public interface ITagRepository
    {
        Tag Find(int TagId);
        void AddTag(Tag Tag);
        void UpdateTag(Tag Tag);
        void DeleteTag(Tag Tag);
        void DeleteTag(int TagId);
        IList<Tag> GetAllTags();
        Tag GetTagByUrlSlug(string urlSlug);
    }
}
