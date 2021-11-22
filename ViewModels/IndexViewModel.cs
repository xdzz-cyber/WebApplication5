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
    }
}
