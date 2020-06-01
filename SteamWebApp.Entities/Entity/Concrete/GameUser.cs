using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
    public class GameUser
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
