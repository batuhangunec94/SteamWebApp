using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SteamWebApp.BLL.Entity.Concrete
{
    public class GameManager : IGameService
    {
        private IGameRepository _gameRepository;
        public GameManager(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public void Add(Game entity)
        {
            _gameRepository.Add(entity);
        }

        public void Add(Game entity, int[] categoryIds)
        {
            _gameRepository.Add(entity, categoryIds);
        }

        public bool Any(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game entity)
        {
            _gameRepository.Delete(entity);
        }

        public List<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public List<Game> GetAllByCategories()
        {
            return _gameRepository.GetAllByCategories();
        }

        public Game GetByDefault(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Game GetById(int id)
        {
            return _gameRepository.GetById(id);
        }

        public Game GetByIdWithCategories(int id)
        {
            return _gameRepository.GetByIdWithCategories(id);
        }

        public Game GetByWithCategories(int id)
        {
            return _gameRepository.GetByWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _gameRepository.GetCountByCategory(category);
        }

        public List<Game> GetDefault(Expression<Func<Game, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGameByUser()
        {
            return _gameRepository.GetGameByUser();
        }

        public Game GetGameDetails(int id)
        {
            return _gameRepository.GetGameDetails(id);
        }

        public Game GetGameDetailsByUser(int id)
        {
            return _gameRepository.GetGameDetailsByUser(id);
        }

        public List<Game> GetGamesByCategory(string category, int page, int pageSize)
        {
            return _gameRepository.GetGamesByCategory(category, page, pageSize);
        }

        public void Update(Game entity)
        {
            _gameRepository.Update(entity);
        }

        public void Update(Game entity, int[] categoryIds)
        {
            _gameRepository.Update(entity,categoryIds);
        }
    }
}
