using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
    public class Category:Base
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategoryGame> CategoryGames { get; set; }

    }
}
