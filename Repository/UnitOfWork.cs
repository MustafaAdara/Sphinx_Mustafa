using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        public IProductRepository productRepository { get; }
        public IClientRepository clientRepository { get; }
        public IClientProductRepository clientProductRepository { get; }

        public UnitOfWork(AppDbContext context, 
                          IClientRepository clientRepository,
                          IProductRepository productRepository,
                          IClientProductRepository clientProductRepository)
        {
            _context = context;
            this.clientRepository = clientRepository;
            this.productRepository = productRepository;
            this.clientProductRepository = clientProductRepository;
        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
