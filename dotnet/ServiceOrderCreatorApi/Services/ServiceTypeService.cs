using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceType;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;

namespace ServiceOrderCreatorApi.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public Task<ServiceTypeDTO> CreateAsync(CreateServiceTypeDTO createServiceTypeDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceTypeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceTypeDTO> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceTypeDTO> UpdateAsync(int Id, UpdateServiceTypeDTO updateServiceTypeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
