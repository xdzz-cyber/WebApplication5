using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Client : Person
    {

        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; } = "";
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; } = "";
        [Column(TypeName = "nvarchar(50)")]
        public string Phone { get; set; } = "";
        [Column(TypeName = "text")]
        public string Note { get; set; } = "";
    }
}
