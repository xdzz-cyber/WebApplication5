using WebApplication5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Data;
using WebApplication5.Data.Repository;
using WebApplication5.Data.FileManager;
using WebApplication5.ViewModels;
using WebApplication5.Models.Comments;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            var items = categoryId == null ? _repo.GetAllItems() : _repo.GetAllItems().Where(item => item.CategoryId == categoryId);
            var categories = _repo.GetAllCategories();

            var IndexViewModelItem = new IndexViewModel
            {
                Items = items,
                Categories = categories
            };

            return View(IndexViewModelItem);
        }



        [HttpGet]
        public IActionResult Items()
        {
            var items = _repo.GetAllItems();
            return View(items);
        }

        [HttpGet]
        public IActionResult Item(int id)
        {
            var item = _repo.GetItem(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult Categories()
        {
            var categories = _repo.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Category(int id)
        {
            var category = _repo.GetCategory(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Basket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Item", new { id = vm.ItemId });
            }

            var item = _repo.GetItem(vm.ItemId);

            if (vm.MainCommentId == 0)
            {
                //Adding subComment
                item.MainComments = item.MainComments ?? new List<MainComment>();
                item.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    CreatedAt = DateTime.Now
                });

                _repo.UpdateItem(item);
            }
            else
            {
                //Adding mainComment
                var subComment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    CreatedAt = DateTime.Now
                };

                _repo.AddSubComment(subComment);
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Item", new { id = vm.ItemId });
        }


        [HttpGet("/Image/{image}")]
        [ResponseCache(CacheProfileName = "Monthly")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf(".") + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}"); 
        }

    }
}
