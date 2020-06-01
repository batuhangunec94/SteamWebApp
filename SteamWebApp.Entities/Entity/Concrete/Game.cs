using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
    public class Game:Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        
        public virtual ICollection<CategoryGame> CategoryGames { get; set; }
        public virtual ICollection<GameUser> GameUsers { get; set; }

    }
}
