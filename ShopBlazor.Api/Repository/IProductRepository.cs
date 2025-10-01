using ShopBlazor.Api.Entities;

namespace ShopBlazor.Api.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetItens();
    Task<Product> GetItem(long id);
    Task<IEnumerable<Product>> GetItensByCategory(long id);
}
