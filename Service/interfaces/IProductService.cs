using Application.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAync();
        Task<ProductDto> GetProductByIdAsync(string id);
        Task AddProduct(ProductDto productDto);
        Task UpdateProduct(ProductDto productDto);
        Task DeleteProduct(string id);
        Task<IEnumerable<ProductDto>> GetProductWithPaging(int page, int pageSize);
        Task<int> CountProducts();

    }
}
