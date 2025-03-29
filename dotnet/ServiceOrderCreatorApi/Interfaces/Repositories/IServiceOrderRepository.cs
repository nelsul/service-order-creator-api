using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces.Repositories
{
    public interface IServiceOrderRepository
    {
        Task<List<ServiceOrder>> GetAllByUserIdAsync(string userId);

        Task<ServiceOrder> GetByIdAsync(string guid);

        Task<ServiceOrder> CreateAsync(ServiceOrder serviceOrder);

        Task<ServiceOrder> UpdateAsync(string guid, ServiceOrder serviceOrder);

        Task<bool> DeleteAsync(string guid);
    }
}
