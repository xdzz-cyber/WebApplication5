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

namespace WebApplication5.Controllers
{
    public class BasketController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public BasketController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }


        [HttpGet]
        public IActionResult Basket()
        {
            return View();
        }
    }
}
