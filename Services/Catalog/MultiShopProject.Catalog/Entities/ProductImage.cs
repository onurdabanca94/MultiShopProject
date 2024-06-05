namespace MultiShopProject.Catalog.Entities;

public class ProductImage
{
    public string ProductImageID { get; set; }
    public string ImgOne { get; set; }
    public string ImgSecond { get; set; }
    public string ImgThird { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
}
