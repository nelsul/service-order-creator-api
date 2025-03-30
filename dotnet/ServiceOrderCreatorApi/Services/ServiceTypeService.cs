using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceType;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;

namespace ServiceOrderCreatorApi.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<ServiceTypeDTO> CreateAsync(CreateServiceTypeDTO createServiceTypeDTO)
        {
            var serviceType = createServiceTypeDTO.ToServiceType();

            serviceType = await _serviceTypeRepository.CreateAsync(serviceType);

            return serviceType.ToDTO();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceTypeDTO>> GetAllAsync()
        {
            var serviceTypes = await _serviceTypeRepository.GetAllAsync();

            return serviceTypes.Select(st => st.ToDTO()).ToList();
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
