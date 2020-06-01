using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.DAL.Entity.Abstraction
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetByWithGame(int id);
        void DeleteFromCategory(int categoryId, int gameId);
    }
}
