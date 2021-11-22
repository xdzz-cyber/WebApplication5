using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Admin : Person
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; } = "";
    }
}
