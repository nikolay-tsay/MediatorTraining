using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopDomain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public List<Product> ProductList { get; set; }
    }
}