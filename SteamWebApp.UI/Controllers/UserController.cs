using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.Entities.Entity.Concrete;
using SteamWebApp.UI.Models.VM;

namespace SteamWebApp.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IGameUserService _gameUserService;
        private IGameService _gameService;
        private ICommentService _commentService;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IGameUserService gameUserService,IGameService gameService, ICommentService commentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _gameUserService = gameUserService;
            _gameService = gameService;
            _commentService = commentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToLibrary(string userName,int gameId)
        {
            
            User user = await _userManager.FindByNameAsync(userName);
            var userId = user.Id;
            GameUser entity = new GameUser()
            {
                GameId = gameId,
                UserId = userId
            };
            _gameUserService.Add(entity);

            return Redirect("/Home/Details/"+gameId);
        }
        public async Task<IActionResult> GameList()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                User entity = _gameUserService.GetLibraryForUser(user.Id);
                return View(entity);

            }
            else
            {
                return Redirect("~/");
            }
            
        }
        [HttpPost]
        public IActionResult DeleteGameForUser(string userId, int gameId)
        {
            _gameUserService.DeleteFromLibrary(userId, gameId);
            return Redirect("/user/gamelist/");
        }

        [HttpPost]
        public async Task<IActionResult> submitComment(int gameId, string userName, string content)
        {
            User user = await _userManager.FindByNameAsync(userName);
            Game game = _gameService.GetById(gameId);
            Comment entity = new Comment()
            {
                Content = content,
                GameId = gameId,
                User = user,
                Game = game,

            };
            _commentService.Add(entity);
            return Redirect("/Home/Details/"+gameId);
        }
        [HttpPost]
        public IActionResult DeleteComment(int gameId,int commentId)
        {
            Comment comment = _commentService.GetById(commentId);
            _commentService.Delete(comment);
            return Redirect("/Home/Details/"+gameId);
        }


    }
}