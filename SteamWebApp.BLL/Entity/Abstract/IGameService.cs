using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Abstract
{
    public interface IGameService
    {
        void Add(Game entity);
        void Add(Game entity, int[] categoryIds);
        void Update(Game entity);
        void Update(Game entity, int[] categoryIds);
        void Delete(Game entity);
        Game GetByWithCategories(int id);
        bool Any(Expression<Func<Game, bool>> exp);

        Game GetById(int id);
        Game GetByDefault(Expression<Func<Game, bool>> exp);

        List<Game> GetDefault(Expression<Func<Game, bool>> exp);
        List<Game> GetAll();
        Game GetByIdWithCategories(int id);
        List<Game> GetAllByCategories();
        int GetCountByCategory(string category);
        List<Game> GetGamesByCategory(string category, int page, int pageSize);
        Game GetGameDetails(int id);
        Game GetGameDetailsByUser(int id);
        List<Game> GetGameByUser();
    }
}
