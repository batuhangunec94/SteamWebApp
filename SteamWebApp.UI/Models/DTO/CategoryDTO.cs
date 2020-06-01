using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Game> Games { get; set; }
    }
}
