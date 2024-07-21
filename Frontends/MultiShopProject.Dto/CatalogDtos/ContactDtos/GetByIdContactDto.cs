namespace MultiShopProject.Dto.CatalogDtos.ContactDtos;

public class GetByIdContactDto
{
    public string ContactId { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendDate { get; set; }
}
