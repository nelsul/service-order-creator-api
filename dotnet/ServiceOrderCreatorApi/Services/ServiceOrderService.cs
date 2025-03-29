using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;

namespace ServiceOrderCreatorApi.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public ServiceOrderService(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public Task<ServiceOrderDTO> AddImageAsync(
            string userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        )
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceOrderDTO> CreateAsync(
            string userId,
            CreateServiceOrderDTO createServiceOrderDTO
        )
        {
            var serviceOrder = createServiceOrderDTO.ToServiceOrder();

            serviceOrder.Guid = Guid.NewGuid().ToString();

            serviceOrder = await _serviceOrderRepository.CreateAsync(serviceOrder);

            return serviceOrder.ToDTO();
        }

        public Task<bool> DeleteAsync(string userId, string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShortServiceOrderDTO>> GetAllAsync(string userId)
        {
            var serviceOrders = await _serviceOrderRepository.GetAllByUserIdAsync(userId);

            return [.. serviceOrders.Select(so => so.ToShortDTO())];
        }

        public Task<ServiceOrderDTO> GetByIdAsync(string userId, string guid)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderDTO> RemoveImageAsync(
            string userId,
            RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        )
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderDTO> UpdateAsync(
            string userId,
            string guid,
            UpdateServiceOrderDTO updateServiceOrderDTO
        )
        {
            throw new NotImplementedException();
        }
    }
}
