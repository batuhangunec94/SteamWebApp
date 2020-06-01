using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.DTO
{
    public class CommentDTO
    {
        
        public int GameId { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
