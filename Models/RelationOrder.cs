using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class RelationOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("FK_Client")]
        public int Client { get; set; }
        [Required]
        [ForeignKey("FK_Item")]
        public int Item { get; set; }
        public int ItemCount { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
