namespace Ecommerce.Application.Features.Currency.Queries.GetAllProducts;

public class MediaDto
{
    public int MediaId { get; set; }
    public int Priority { get; set; }
    public string Url { get; set; }
    public MediaType Type { get; set; }
}

public enum MediaType
{
    Image,
    Video
}