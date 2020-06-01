using Microsoft.EntityFrameworkCore;
using SteamWebApp.DAL.Entity.Abstraction;
using SteamWebApp.DAL.Entity.Concrete.EfCore.Context;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamWebApp.DAL.Entity.Concrete.EfCore
{
    public class EfGameUserRepository : IGameUserRepository
    {
        private ProjectContext _context;
        public EfGameUserRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(GameUser entity)
        {
            GameUser gameUser = new GameUser();
            gameUser.GameId = entity.GameId;
            gameUser.UserId = entity.UserId;

            _context.Add(gameUser);
            _context.SaveChanges();
        }
        public User GetLibraryForUser(string id)
        {
            return _context.Users
                .Where(x => x.Id == id)
                .Include(x => x.GameUsers)
                .ThenInclude(x => x.Game)
                .FirstOrDefault();


        }
        

        public void DeleteFromLibrary(string userId, int gameId)
        {
            using (_context)
            {
                var tSql = @"delete from GameUser where GameId=@p0 And UserId=@p1";
                _context.Database.ExecuteSqlRaw(tSql, gameId, userId);
            }

        }
    }
}
