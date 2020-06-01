using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.DAL.Entity.Abstraction
{
    public interface ICommentRepository:IRepository<Comment>
    {
        List<Comment> GetCommentWithUser(int gameId);
    }
}
