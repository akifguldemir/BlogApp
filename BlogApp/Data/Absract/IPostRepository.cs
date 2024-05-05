using BlogApp.Entity;

namespace BlogApp.Data.Absract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts{ get; }

        void CreatePost(Post post);
    }
}