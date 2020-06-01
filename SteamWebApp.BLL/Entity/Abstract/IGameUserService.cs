using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.BLL.Entity.Abstract
{
    public interface IGameUserService
    {
        void Add(GameUser entity);
        User GetLibraryForUser(string id);
        void DeleteFromLibrary(string userId, int gameId);
    }
}
