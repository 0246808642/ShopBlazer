using System.ComponentModel.DataAnnotations;

namespace ShopBlazor.Models.DTOs;

public class CategoryDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IconCSS { get; set; } = string.Empty;
}
