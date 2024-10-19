using Application.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IClientProductService
    {
        public Task<IEnumerable<ClientProductDto>> GetAllByClientId(string clientId);
        Task AddClientWithActiveProduct(ClientProductDto clientProductDto);
        Task<ClientProductDto> GetByIdAsync(string clientId, string productId);
        Task DeleteAsync(string clientId, string productId);
        Task UpdateClientProduct(ClientProductDto clientProductDto);
    }
}
