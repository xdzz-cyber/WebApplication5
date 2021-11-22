﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.ViewModels
{
    public class LoginViewModel
    {
        public string Username{ get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
