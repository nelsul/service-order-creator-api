using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Interfaces.Services;
using ServiceOrderCreatorApi.Mappers;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Services
{
    public class ServiceOrderService : IServiceOrderService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly string _storagePath;

        public ServiceOrderService(
            IServiceOrderRepository serviceOrderRepository,
            IImageStorageService imageStorageService
        )
        {
            _serviceOrderRepository = serviceOrderRepository;
            _imageStorageService = imageStorageService;
            _storagePath = "/Users/nelsonneto/dev/service_order_creator/api/storage/service-orders";
        }

        public async Task<ServiceOrderDTO> AddImageAsync(
            string userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                addImageServiceOrderDTO.Guid
            );

            if (serviceOrder == null)
            {
                throw new FileNotFoundException("Service Order not found");
            }

            if (serviceOrder.UserId != userId)
            {
                throw new UnauthorizedAccessException(
                    "Not uthorized to make changes to this service order"
                );
            }

            var fileName = await _imageStorageService.StoreAsync(
                Path.Combine(_storagePath, serviceOrder.Guid),
                addImageServiceOrderDTO.Image!
            );

            serviceOrder.ImageFiles.Add(fileName);

            serviceOrder = await UpdateChangesAsync(
                serviceOrder.Guid,
                null,
                serviceOrder.ImageFiles
            );

            return serviceOrder.ToDTO();
        }

        public async Task<ServiceOrderDTO> CreateAsync(
            string userId,
            CreateServiceOrderDTO createServiceOrderDTO
        )
        {
            var serviceOrder = createServiceOrderDTO.ToServiceOrder();

            serviceOrder.Guid = Guid.NewGuid().ToString();

            serviceOrder.UserId = userId;

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

        public async Task<ServiceOrderDTO> UpdateAsync(
            string userId,
            string guid,
            UpdateServiceOrderDTO updateServiceOrderDTO
        )
        {
            var serviceOrder = await UpdateChangesAsync(
                guid,
                updateServiceOrderDTO.Description,
                null
            );

            return serviceOrder.ToDTO();
        }

        private async Task<ServiceOrder> UpdateChangesAsync(
            string guid,
            string? description,
            List<string>? images
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(guid);

            if (serviceOrder == null)
            {
                throw new Exception("Service order not found to update");
            }

            if (description != null)
            {
                serviceOrder.Description = description;
            }

            if (images != null)
            {
                serviceOrder.ImageFiles = images;
            }

            serviceOrder = await _serviceOrderRepository.UpdateAsync(serviceOrder);

            return serviceOrder;
        }
    }
}
