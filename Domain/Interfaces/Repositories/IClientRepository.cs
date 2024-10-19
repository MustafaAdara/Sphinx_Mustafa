using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllPaged(int page, int pageSize);
        Task<int> CountAsync();
        Task<bool> ExistsAsync(string id);
        Task<Client> GetByIdWithProducts(string id);
    }
}
