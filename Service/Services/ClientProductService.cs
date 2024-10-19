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
    public class ClientProductService : IClientProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddClientWithActiveProduct(ClientProductDto clientProductDto)
        {
            var clientProduct = _mapper.Map<ClientProduct>(clientProductDto);

            var product = await _unitOfWork.productRepository.GetById(clientProduct.ProductId);
            if (product == null || !product.IsActive)
            {
                throw new InvalidOperationException("Cannot add an inactive or non-existent product to a client.");
            }
            await _unitOfWork.clientProductRepository.Add(clientProduct);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(string clientId, string productId)
        {
            await _unitOfWork.clientProductRepository.DeleteAsync(clientId, productId);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<ClientProductDto>> GetAllByClientId(string clientId)
        {
            var clientspro = await _unitOfWork.clientProductRepository.GetAllByClientId(clientId);
            return _mapper.Map<IEnumerable<ClientProductDto>>(clientspro);
        }

        public async Task<ClientProductDto> GetByIdAsync(string clientId, string productId)
        {
            var clientProduct = await _unitOfWork.clientProductRepository.GetByIdAsync(clientId, productId);
            return _mapper.Map<ClientProductDto>(clientProduct);
        }

        public async Task UpdateClientProduct(ClientProductDto clientProductDto)
        {
            var clientProduct = _mapper.Map<ClientProduct>(clientProductDto);
            _unitOfWork.clientProductRepository.Update(clientProduct);
            await _unitOfWork.Complete();
        }
    }
}
