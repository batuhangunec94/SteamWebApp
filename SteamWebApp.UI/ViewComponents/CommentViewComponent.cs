using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        private ICommentService _commentService;
        private UserManager<User> _userManager;
        public CommentViewComponent(ICommentService commentService, UserManager<User> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        public IViewComponentResult Invoke(int gameId)
        {

            List<Comment> model = _commentService.GetCommentWithUser(gameId);
            

            return View(model);
        }
    }
}
