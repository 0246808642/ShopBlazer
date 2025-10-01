using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBlazor.Api.Entities;

public class Product
{
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(300)]
    public string ImageUrl { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Chave estrangeira para a categoria
    public long CategoryId { get; set; }

    // Propriedade de navegação
    public Category? Category { get; set; }

    // Relacionamento com itens do carrinho
    public Collection<ItemCart> Itens { get; set; } = new Collection<ItemCart>();
}
