using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientProductRepository : IGenericRepository<ClientProduct>
    {
        public Task<IEnumerable<ClientProduct>> GetAllByClientId(string clientId);
        Task<ClientProduct> GetByIdAsync(string clientId, string productId);
        Task DeleteAsync(string clientId, string productId);
    }
}
