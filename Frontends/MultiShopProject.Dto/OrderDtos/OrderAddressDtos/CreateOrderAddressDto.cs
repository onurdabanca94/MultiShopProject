namespace MultiShopProject.Dto.OrderDtos.OrderAddressDtos;

public class CreateOrderAddressDto
{
    //public int AddressId { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string Disctrict { get; set; }
    public string City { get; set; }
    public string DetailFirst { get; set; }
    public string DetailSecond { get; set; }
    public string Description { get; set; }
    public string ZipCode { get; set; }
}
