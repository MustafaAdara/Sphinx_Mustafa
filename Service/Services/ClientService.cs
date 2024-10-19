using Application.DTOs;
using Application.interfaces;
using AutoMapper;
using Domain.Entites;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = Guid.NewGuid().ToString();
            await _unitOfWork.clientRepository.Add(client);
            await _unitOfWork.Complete();
        }

        public async Task DeleteClient(string id)
        {
            var client = await _unitOfWork.clientRepository.GetById(id);
            _unitOfWork.clientRepository.Delete(client);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<ClientDto>> GetAllPagedClient(int page, int pageSize)
        {
            var clients = await _unitOfWork.clientRepository.GetAllPaged(page, pageSize);
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<IEnumerable<ClientDto>> GetAllClient()
        {
            var clients = await _unitOfWork.clientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetClientById(string id)
        {
            var client = await _unitOfWork.clientRepository.GetById(id);
            if (client == null) { throw new Exception("Can not find this object"); };
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDetailsDto> GetClientDetails(string id)
        {
            var client = await _unitOfWork.clientRepository.GetByIdWithProducts(id);
            return _mapper.Map<ClientDetailsDto>(client);
        }

        public async Task UpdateClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            var editedclient = await _unitOfWork.clientRepository.GetById(client.Id);
            if (editedclient == null) return;

            editedclient.Name = client.Name;
            editedclient.Class = client.Class;
            editedclient.State = client.State;

            _unitOfWork.clientRepository.Update(editedclient);
            await _unitOfWork.Complete();
        }

        public async Task<int> CountClients()
        {
            return await _unitOfWork.clientRepository.CountAsync();
        }
    }
}
