using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopDomain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)] 
        public string FirstName { get; set; } 
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int LandRegistryNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        public List<Order> OrderList { get; set; }
    }
}