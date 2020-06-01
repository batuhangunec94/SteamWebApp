using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamWebApp.BLL.Entity.Abstract;
using SteamWebApp.Entities.Entity.Concrete;
using SteamWebApp.UI.Models.DTO;
using SteamWebApp.UI.Models.VM;

namespace SteamWebApp.UI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IGameService _gameService;
        private ICategoryService _categoryService;
        public AdminController(IGameService gameService, ICategoryService categoryService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
        }
        
        public IActionResult GameList()
        {
            //ViewBag.Categories = _categoryService.GetAll();
            List<Game> model = _gameService.GetAllByCategories();
            return View(model);
            
        }
        [HttpGet]
        public IActionResult AddGame()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGame(GameDTO model,int[] categoryIds,IFormFile file)
        {
            if (ModelState.IsValid==true)
            {
                var entity = new Game()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,

                };

                if (file != null)
                {
                    var randomName = Guid.NewGuid().ToString();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName + ".jpg");
                    entity.Image = randomName + ".jpg";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    entity.Image = model.Image;
                }
                
                _gameService.Add(entity, categoryIds);

                return RedirectToAction("GameList");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);

                 
        }
        [HttpGet]
        public IActionResult EditGame(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Game entity = _gameService.GetByIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new GameDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Image,
                Price = entity.Price,
                SelectedCategories = entity.CategoryGames.Select(x => x.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditGame(GameDTO model,int[] categoryIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {

            

            var entity = _gameService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            
                if (file != null)
                {
                    //entity.Image = file.FileName;
                    var randomName = Guid.NewGuid().ToString();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName+".jpg");
                    entity.Image = randomName + ".jpg";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            entity.Price = model.Price;

            _gameService.Update(entity,categoryIds);
            return RedirectToAction("GameList");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult DeleteGame(int id)
        {
            var entity = _gameService.GetById(id);
            if (entity != null)
            {
                _gameService.Delete(entity);
            }
            return RedirectToAction("GameList");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListVM
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = model.Name,
                    Description = model.Description

                };
                _categoryService.Add(entity);
                return RedirectToAction("CategoryList");
            }
            else
            {
                return View(model);
            }
            

        }
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            var model = _categoryService.GetByWithGame((int)id);
            
            return View(new CategoryDTO() { 
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Games = model.CategoryGames.Select(g => g.Game).ToList()
                
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryDTO model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var entity = _categoryService.GetById(id);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int gameId)
        {
             _categoryService.DeleteFromCategory(categoryId, gameId);
            return Redirect("/admin/editcategory/"+categoryId);
        }
     
        
    }
}