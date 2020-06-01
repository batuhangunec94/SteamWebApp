using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Abstract
{
    public interface ICategoryService
    {
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByWithGame(int id);
        bool Any(Expression<Func<Category, bool>> exp);

        Category GetById(int id);
        Category GetByDefault(Expression<Func<Category, bool>> exp);

        List<Category> GetDefault(Expression<Func<Category, bool>> exp);
        List<Category> GetAll();
        void DeleteFromCategory(int categoryId, int gameId);
    }
}
