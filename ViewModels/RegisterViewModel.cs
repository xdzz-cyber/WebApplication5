using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.ViewModels
{
    public class RegisterViewModel
    {
        public string Username{ get; set; }
        public string Email{ get; set; }
        public string Address{ get; set; }
        public string Note{ get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
