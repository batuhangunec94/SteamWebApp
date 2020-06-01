using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Abstract
{
    public interface ICommentService
    {
        void Add(Comment entity);
        void Update(Comment entity);
        void Delete(Comment entity);

        bool Any(Expression<Func<Comment, bool>> exp);

        Comment GetById(int id);
        Comment GetByDefault(Expression<Func<Comment, bool>> exp);

        List<Comment> GetDefault(Expression<Func<Comment, bool>> exp);
        List<Comment> GetAll();
        List<Comment> GetCommentWithUser(int gameId);
    }
}
