using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public bool Any(Expression<Func<Category, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int categoryId, int gameId)
        {
            _categoryRepository.DeleteFromCategory(categoryId, gameId);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetByDefault(Expression<Func<Category, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByWithGame(int id)
        {
            return _categoryRepository.GetByWithGame(id);
        }

        public List<Category> GetDefault(Expression<Func<Category, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
