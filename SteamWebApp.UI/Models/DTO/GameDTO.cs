using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30,MinimumLength =2,ErrorMessage = "minimum 2 letters, maximum 30 letters")]
        public string Name { get; set; }
        [Required]
        [StringLength(300,MinimumLength =30,ErrorMessage = "minimum 30 letters, maximum 150 letters")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Choose Image")]
        public string Image { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
