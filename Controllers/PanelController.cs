using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Data.FileManager;
using WebApplication5.Data.Repository;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public PanelController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _repo.GetAllItems();
            var totalItemsSum = _repo.GetAllItems().Sum(item => item.Price);

            var panelIndexVM = new PanelIndexViewModel();
            panelIndexVM.Items = items;
            panelIndexVM.totalItemsSum = totalItemsSum;

            return View(panelIndexVM);
        }



        [HttpGet]
        public IActionResult EditItem(int? id)
        {
            if(id == null)
            {
                return View(new ItemViewModel {
                    Categories = _repo.GetAllCategories()
                });
            }
            var item = _repo.GetItem((int)id);


            var model = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Description = item.Description,
                CategoryId = item.CategoryId,
                Categories = _repo.GetAllCategories(),
                CurrentImage = item.Photo
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if(id == null)
            {
                return View(new Category());
            }
            var category = _repo.GetCategory((int)id);
            return View(new Category {
               Id = category.Id,
               Name = category.Name
            });
        }



        [HttpPost]
        public async Task<IActionResult> EditItem(ItemViewModel vm)
        {
            var item = new Item
            {
                Id = vm.Id,
                Name = vm.Name,
                Price = vm.Price,
                Description = vm.Description,
                Quantity = vm.Quantity,
                CategoryId = vm.CategoryId
            };

            if(vm.Photo == null)
            {
                item.Photo = vm.CurrentImage;
            }
            else
            {
                if (!string.IsNullOrEmpty(vm.CurrentImage))
                {
                    _fileManager.RemoveImage(vm.CurrentImage);
                }
                item.Photo = await _fileManager.SaveImage(vm.Photo);
            }

            if(item.Id > 0)
            {
                _repo.UpdateItem(item);
            }
            else
            {
                _repo.AddItem(item);
            }

            if(await _repo.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category c)
        {
            if (c.Id > 0)
            {
                _repo.UpdateCategory(c);
            }
            else
            {
                _repo.AddCategory(c);
            }

            if(await _repo.SaveChangesAsync())
            {
                return RedirectToAction("Categories", "Home");
            }

            return View(c);
        }


        [HttpGet]
        public async Task<IActionResult> RemoveItem(int id)
        {
            _fileManager.RemoveImage(_repo.GetItem(id).Photo);
            _repo.RemoveItem(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            _repo.RemoveCategory(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Categories", "Home");
        }
    }
}
