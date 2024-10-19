using Domain.Entites;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> CountProducts()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<IEnumerable<Product>> GetProductWithPaging(int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            var pagedProduct = await query.OrderBy(x => x.Name)
                                           .Skip((page-1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();
            return pagedProduct;
        }

        public async Task<bool> HasRelatedClientProductsAsync(string id)
        {
            return await _context.ClientProducts.AnyAsync(x => x.ProductId == id);
        }
    }
}
