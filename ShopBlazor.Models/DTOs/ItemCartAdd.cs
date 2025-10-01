using System.ComponentModel.DataAnnotations;

namespace ShopBlazor.Models.DTOs;

public class ItemCartAdd
{
    [Required]
    public long CartId { get; set; }
    [Required]
    public long ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
