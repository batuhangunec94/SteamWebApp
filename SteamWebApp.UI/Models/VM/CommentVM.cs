using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.VM
{
    public class CommentVM
    {
        public List<Comment> Comments { get; set; }
        public List<User> Users { get; set; }


    }
}
