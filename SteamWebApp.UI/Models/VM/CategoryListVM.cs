using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.Models.VM
{
    public class CategoryListVM
    {
        public List<Category> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}
