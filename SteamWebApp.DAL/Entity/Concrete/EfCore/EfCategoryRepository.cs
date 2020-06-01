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
    public class EfCategoryRepository:EfBaseRepository<Category>,ICategoryRepository
    {
        private ProjectContext _context;
        public EfCategoryRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteFromCategory(int categoryId, int gameId)
        {
            using (_context)
            {
                var tSql = @"delete from CategoryGame where CategoryId=@p0 And GameId=@p1";
                _context.Database.ExecuteSqlRaw(tSql, categoryId, gameId);
            }
            
        }

        public Category GetByWithGame(int id)
        {
            return _context.Categories
                .Where(x => x.Id == id)
                .Include(x => x.CategoryGames)
                .ThenInclude(x => x.Game)
                .FirstOrDefault();
        }
    }
}
