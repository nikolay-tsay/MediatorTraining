namespace WebShopDomain.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 

        public string Email { get; set; } 
        public string PhoneNumber { get; set; }

        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int LandRegistryNumber { get; set; }
        public string City { get; set; } 
        public string PostCode { get; set; }
    }
}