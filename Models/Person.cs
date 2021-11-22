using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = "";
    }
}
