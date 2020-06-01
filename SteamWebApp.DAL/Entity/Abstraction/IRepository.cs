using SteamWebApp.Entities.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.DAL.Entity.Abstraction
{
    public interface IRepository<T> where T : class,ICore,new ()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        bool Any(Expression<Func<T, bool>> exp);

        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
    }
}
