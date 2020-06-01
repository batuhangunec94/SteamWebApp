using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.VM
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }

    }
    public class GameListVM
    {
        public List<Game> Games { get; set; }
        public PageInfo PageInfo { get; set; }
        public List<Category> Categories { get; set; }
        public List<CategoryGame> CategoryGames { get; set; }
    }
}
