using BlogApp.Entity;

namespace BlogApp.Data.Absract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags{ get; }

        void CreateTag(Tag tag);
    }
}