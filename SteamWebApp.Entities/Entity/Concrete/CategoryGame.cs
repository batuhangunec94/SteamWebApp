using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
    public class CategoryGame
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
