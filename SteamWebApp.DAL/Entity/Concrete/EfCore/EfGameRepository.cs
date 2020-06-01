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
    public class EfGameRepository:EfBaseRepository<Game>,IGameRepository
    {
        private ProjectContext _context;
        public EfGameRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Game entity, int[] categoryIds)
        {
            entity.CategoryGames = categoryIds.Select(x => new CategoryGame()
            {
                CategoryId = x,
                GameId = entity.Id
            }).ToList();
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<Game> GetAllByCategories()
        {
            return _context.Games.Include(x => x.CategoryGames).ThenInclude(x => x.Category).ToList();
        }
        public List<Game> GetGameByUser()
        {
            return _context.Games.Include(x => x.GameUsers).ThenInclude(x => x.UserId).ToList();
        }

        public Game GetByIdWithCategories(int id)
        {
            return _context.Games
                .Where(x => x.Id == id)
                .Include(x => x.CategoryGames)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();
        }

        public Game GetByWithCategories(int id)
        {
            return _context.Games
                .Where(x => x.Id == id)
                .Include(x => x.CategoryGames)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();
                
        }

        public void Update(Game entity, int[] categoryIds)
        {
            var game = _context.Games
                .Include(x => x.CategoryGames)
                .FirstOrDefault(x => x.Id == entity.Id);
            if (game!=null)
            {
                game.Name = entity.Name;
                game.Description = entity.Description;
                game.Image = entity.Image;
                game.Price = entity.Price;
                game.CategoryGames = categoryIds.Select(x => new CategoryGame()
                {
                    CategoryId = x,
                    GameId = entity.Id
                }).ToList();
                _context.SaveChanges();
            }
        }
        public List<Game> GetGamesByCategory(string category, int page, int pageSize) {
            var games = _context.Games.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                games = games.Include(x => x.CategoryGames)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.CategoryGames.Any(x => x.Category.Name.ToLower() == category.ToLower()));
            }
            return games.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCountByCategory(string category)
        {
            
                var games = _context.Games.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    games = games
                                .Include(x => x.CategoryGames)
                                .ThenInclude(x => x.Category)
                                .Where(x => x.CategoryGames.Any(x => x.Category.Name.ToLower() == category.ToLower()));
                }
                return games.Count();
            }

        public Game GetGameDetails(int id)
        {
            return _context.Games
                .Where(x => x.Id == id)
                .Include(x => x.CategoryGames)
                .ThenInclude(x => x.Category)
                .FirstOrDefault();
        }
        public Game GetGameDetailsByUser(int id)
        {
            return _context.Games
                .Where(x => x.Id == id)
                .Include(x => x.GameUsers)
                .FirstOrDefault();
        }
    }
    }
