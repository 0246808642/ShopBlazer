namespace ShopBlazor.Models.DTOs;

public class ItemCartDto
{
    public long Id { get; set; }
    public long CartId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }

    // Propriedades de navegação
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductImageUrl { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
}
