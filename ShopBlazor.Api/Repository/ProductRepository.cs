using Microsoft.EntityFrameworkCore;
using ShopBlazor.Api.Data;
using ShopBlazor.Api.Entities;

namespace ShopBlazor.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetItem(long id)
        {
            var item = await _context.Products.Include(p=>p.Category).SingleOrDefaultAsync(c=>c.Id == id);
            return item;
        }

        public async Task<IEnumerable<Product>> GetItens()
        {
            var itens = await _context.Products.Include(p=>p.Category).ToListAsync();
            return itens;
        }

        public async Task<IEnumerable<Product>> GetItensByCategory(long id)
        {
            var itens = await _context.Products.Include(p=>p.Category)
                .Where(c=>c.CategoryId == id).ToListAsync();
            return itens;
        }
    }
}
