using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.VM
{
    public class GameDetailsVM
    {
        public Game Game { get; set; }
        public List<Category> Categories { get; set; }
        public List<GameUser> GameUsers { get; set; }
        public List<Comment> Comments { get; set; }
        public string userId { get; set; }
        public string Content { get; set; }
    }
}
