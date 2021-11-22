using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models.Comments;

namespace WebApplication5.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0;
        [Column(TypeName = "text")]
        public string Description { get; set; } = "";
        [Column(TypeName = "text")]
        public string Photo { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public DateTime Created_at { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<MainComment> MainComments { get; set; }
    }
}
