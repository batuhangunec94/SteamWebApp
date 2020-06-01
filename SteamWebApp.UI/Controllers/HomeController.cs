using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.Entities.Entity.Concrete;
using SteamWebApp.UI.Models.DTO;
using SteamWebApp.UI.Models.VM;

namespace SteamWebApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private IGameService _gameService;
        private ICommentService _commentService;
        public HomeController(IGameService gameService, UserManager<User> userManager, ICommentService commentService)
        {
            _gameService = gameService;
            _userManager = userManager;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View(new GameListVM()
            {
                Games = _gameService.GetAllByCategories()
            });
        }
        public IActionResult List(string category,int page = 1)
        {
            const int pageSize = 3;
            
            return View(new GameListVM() { 
                PageInfo = new PageInfo() { 
                    TotalItems = _gameService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Games = _gameService.GetGamesByCategory(category, page ,pageSize)
            });
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {

            
            Game game = _gameService.GetGameDetails((int)id);
            Game userGame = _gameService.GetGameDetailsByUser((int)id);
            
            if (game == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var item in userGame.GameUsers)
                {
                    if (user.Id == item.UserId)
                    {
                        GameDetailsVM model = new GameDetailsVM()
                        {
                            Game = game,
                            Categories = game.CategoryGames.Select(x => x.Category).ToList(),
                            GameUsers = userGame.GameUsers.Where(x => x.GameId == id).ToList(),
                            userId = user.Id
                        };
                        return View(model);
                    }
                }
                    GameDetailsVM modelNull = new GameDetailsVM()
                    {
                        Game = game,
                        Categories = game.CategoryGames.Select(x => x.Category).ToList(),
                        GameUsers = userGame.GameUsers.Where(x => x.GameId == id).ToList(),
                        userId = null
                    };
                    return View(modelNull);

                }
            else
            {
                return View(new GameDetailsVM()
                {
                    Game = game,
                    Categories = game.CategoryGames.Select(x => x.Category).ToList(),
                });
            }
            }



        }
        
    }
}