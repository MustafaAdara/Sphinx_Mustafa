using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductWithPaging(int page, int pageSize);
        Task<bool> HasRelatedClientProductsAsync(string id);
        Task<int> CountProducts();
        Task<IEnumerable<Product>> GetAllActive();

    }
}
