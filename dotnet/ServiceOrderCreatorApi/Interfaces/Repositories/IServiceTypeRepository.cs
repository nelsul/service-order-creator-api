using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces.Repositories
{
    public interface IServiceTypeRepository
    {
        Task<List<ServiceType>> GetAllAsync();

        Task<ServiceType?> GetByIdAsync(int Id);

        Task<ServiceType> CreateAsync(ServiceType serviceType);

        Task<ServiceType> UpdateAsync(ServiceType serviceType);

        Task<bool> DeleteAsync(int Id);
    }
}
