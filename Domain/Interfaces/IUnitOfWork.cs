using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository productRepository { get; }
        IClientRepository clientRepository { get; }
        IClientProductRepository clientProductRepository { get; }

        Task Complete();
    }
}
