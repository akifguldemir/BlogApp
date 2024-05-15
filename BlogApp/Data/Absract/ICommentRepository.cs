using BlogApp.Entity;

namespace BlogApp.Data.Absract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments{ get; }

        void CreateComment(Comment Comment);
    }
}