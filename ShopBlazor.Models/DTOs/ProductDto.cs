namespace ShopBlazor.Models.DTOs;

public class ProductDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public long CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
