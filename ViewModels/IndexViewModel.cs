using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Item> Items{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<double> OptimizedPaginationPages{ get; set; }
        public int PageNumber { get; set; }
        public double PagesCount { get; set; }
        public double ItemsCount { get; set; }
        public int? CategoryId{ get; set; }
    }
}
