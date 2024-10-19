using Domain.Entites;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientProductRepository : GenericRepository<ClientProduct>, IClientProductRepository
    {
        public ClientProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteAsync(string clientId, string productId)
        {
            var clientProduct = await GetByIdAsync(clientId, productId);
            _context.ClientProducts.Remove(clientProduct);
        }

        public async Task<IEnumerable<ClientProduct>> GetAllByClientId(string clientId)
        {
            return await _context.ClientProducts
                            .Include(cp => cp.Product)
                            .Where(cp => cp.ClientId == clientId)
                            .OrderBy(cp => cp.Product.Name)
                            .ToListAsync();
        }

        public async Task<ClientProduct> GetByIdAsync(string clientId, string productId)
        {
            return await _context.ClientProducts
                                .Include(cp => cp.Client)
                                .Include(cp => cp.Product)
                                .FirstOrDefaultAsync(cp => cp.ClientId == clientId && cp.ProductId == productId);

        }
    }
}
