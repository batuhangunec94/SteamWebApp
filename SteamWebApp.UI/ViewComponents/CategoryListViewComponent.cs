using Microsoft.AspNetCore.Mvc;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamWebApp.UI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListVM
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}
