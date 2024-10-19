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
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> CountAsync()
        {
            return await _context.Clients.CountAsync();
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Clients.AnyAsync(c=>c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAllPaged(int page, int pageSize)
        {
            var query = _context.Clients.AsQueryable();

            var pagedClient = await query.OrderBy(x => x.Code)
                                           .Skip((page - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();
            return pagedClient;
        }

        public async Task<Client> GetByIdWithProducts(string id)
        {
            return await _context.Clients.Include(c => c.ClientProducts)
                                         .ThenInclude(cp => cp.Product)
                                         .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
