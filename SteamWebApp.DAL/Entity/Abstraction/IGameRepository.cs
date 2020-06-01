using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.DAL.Entity.Abstraction
{
    public interface IGameRepository:IRepository<Game>
    {
        Game GetByWithCategories(int id);
        Game GetByIdWithCategories(int id);
        void Update(Game entity, int[] categoryIds);
        void Add(Game entity,int[]categoryIds);
        List<Game> GetAllByCategories();
        int GetCountByCategory(string category);
        List<Game> GetGamesByCategory(string category,int page , int pageSize);

        Game GetGameDetails(int id);
        Game GetGameDetailsByUser(int id);
        List<Game> GetGameByUser();

    }
}
