namespace MultiShopProject.Order.Application.Features.CQRS.Results.AddressResults;

public class GetAddressByIdQueryResult
{
    public int AddressId { get; set; }
    public string UserId { get; set; }
    public string Disctrict { get; set; }
    public string City { get; set; }
    public string Detail { get; set; }
}
