using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopDomain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public List<Order> OrderList { get; set; }
    }
}