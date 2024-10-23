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
    public class ProductService : IProductService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = Guid.NewGuid().ToString();
            await _unitOfWork.productRepository.Add(product);
            await _unitOfWork.Complete();
        }

        public async Task<int> CountProducts()
        {
            return await _unitOfWork.productRepository.CountProducts();
        }

        public async Task DeleteProduct(string id)
        {
            var product =  await _unitOfWork.productRepository.GetById(id);
            if (product == null) return;
            if (await _unitOfWork.productRepository.HasRelatedClientProductsAsync(id))
            {
                throw new Exception("Can not delete this product due to its connection to another");
            }
             _unitOfWork.productRepository.Delete(product);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<ProductDto>> GetAllActiveProducts()
        {
            var activeProducts = await _unitOfWork.productRepository.GetAllActive();
            return _mapper.Map<IEnumerable<ProductDto>>(activeProducts);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAync()
        {
            var products = await _unitOfWork.productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var product = await _unitOfWork.productRepository.GetById(id);
            if (product == null) { throw new Exception("Can not find this object"); };
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductWithPaging(int page, int pageSize)
        {
            var products = await _unitOfWork.productRepository.GetProductWithPaging(page, pageSize);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var editedProduct = await _unitOfWork.productRepository.GetById(product.Id);
            if (editedProduct == null) return;

            editedProduct.Name = product.Name;
            editedProduct.Description = product.Description;
            editedProduct.IsActive = product.IsActive;
            
            _unitOfWork.productRepository.Update(editedProduct);
            await _unitOfWork.Complete();
        }


    }
}
