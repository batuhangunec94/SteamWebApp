using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.BLL.Entity.Concrete
{
    public class GameUserManager : IGameUserService
    {
        private IGameUserRepository _gameUserRepository;
        public GameUserManager(IGameUserRepository gameUserRepository)
        {
            _gameUserRepository = gameUserRepository;
        }

        public void Add(GameUser entity)
        {
            _gameUserRepository.Add(entity);
        }

        public void DeleteFromLibrary(string userId, int gameId)
        {
            _gameUserRepository.DeleteFromLibrary(userId,gameId);
        }

        public User GetLibraryForUser(string id)
        {
            return _gameUserRepository.GetLibraryForUser(id);
        }
    }
}
