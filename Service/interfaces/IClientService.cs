using Application.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClient();
        Task<IEnumerable<ClientDto>> GetAllPagedClient(int page, int pageSize);
        Task AddClient(ClientDto clientDto);
        Task DeleteClient(string id);
        Task UpdateClient(ClientDto clientDto);
        Task<ClientDto> GetClientById(string id);
        Task<ClientDetailsDto> GetClientDetails(string id);
        Task<int> CountClients();
        Task<bool> IsClientExitsWithSameCode(ClientDto clientDto);
    }
}
