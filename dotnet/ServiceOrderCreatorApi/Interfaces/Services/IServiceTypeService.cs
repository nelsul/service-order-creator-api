using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.DTOs.ServiceType;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IServiceTypeService
    {
        Task<List<ServiceTypeDTO>> GetAllAsync();

        Task<ServiceTypeDTO> GetByIdAsync(int Id);

        Task<ServiceTypeDTO> CreateAsync(CreateServiceTypeDTO createServiceTypeDTO);

        Task<ServiceTypeDTO> UpdateAsync(int Id, UpdateServiceTypeDTO updateServiceTypeDTO);

        Task<bool> DeleteAsync(int Id);
    }
}
