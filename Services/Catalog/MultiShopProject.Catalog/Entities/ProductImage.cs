using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShopProject.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; }
    public string ImgOne { get; set; }
    public string ImgSecond { get; set; }
    public string ImgThird { get; set; }
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
