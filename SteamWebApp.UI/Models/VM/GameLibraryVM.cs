using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.VM
{
    public class GameLibraryVM
    {
        public User User { get; set; }
        public List<Game> Games { get; set; }
    }
}
