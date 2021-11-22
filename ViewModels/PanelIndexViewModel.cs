using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ViewModels
{
    public class PanelIndexViewModel
    {
        public List<Item> Items { get; set; }
        public decimal totalItemsSum { get; set; } = 0;
    }
}
