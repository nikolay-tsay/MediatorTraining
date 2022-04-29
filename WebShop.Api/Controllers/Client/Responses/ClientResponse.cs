namespace WebShopApi.Controllers.Client.Responses
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public string Street { get; set; } = null!;
        public int? HouseNumber { get; set; }
        public int? LandRegistryNumber { get; set; }
        public string City { get; set; } = null!;
        public string PostCode { get; set; } = null!;
    }
}