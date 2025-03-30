using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces.Repositories
{
    public interface IServiceOrderRepository
    {
        Task<List<ServiceOrder>> GetAllByUserIdAsync(Guid userId);

        Task<ServiceOrder?> GetByIdAsync(Guid Id);

        Task<ServiceOrder> CreateAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> UpdateAsync(ServiceOrder serviceOrder);

        Task<bool> DeleteAsync(Guid Id);
    }
}
