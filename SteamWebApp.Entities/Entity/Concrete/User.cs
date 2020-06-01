using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
   public class User:IdentityUser
    {

        public virtual ICollection<GameUser> GameUsers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
