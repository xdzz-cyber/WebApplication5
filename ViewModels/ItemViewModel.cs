using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public string Description { get; set; } = "";
        public string CurrentImage { get; set; } = "";
        public IFormFile Photo { get; set; } = null;
        public int Quantity{ get; set; } = 0;
        public List<Category> Categories { get; set; } = null;
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
    }
}
