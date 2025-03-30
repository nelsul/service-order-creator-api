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
            Guid userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                Guid.Parse(addImageServiceOrderDTO.PublicId)
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
                Path.Combine(_storagePath, serviceOrder.PublicId.ToString()),
                addImageServiceOrderDTO.Image!
            );

            serviceOrder.ImageFiles.Add(fileName);

            serviceOrder = await UpdateChangesAsync(
                serviceOrder.PublicId,
                null,
                null,
                serviceOrder.ImageFiles
            );

            return serviceOrder.ToDTO();
        }

        public async Task<ServiceOrderDTO> CreateAsync(
            Guid userId,
            CreateServiceOrderDTO createServiceOrderDTO
        )
        {
            var serviceOrder = createServiceOrderDTO.ToServiceOrder();

            serviceOrder.PublicId = Guid.NewGuid();

            serviceOrder.UserId = userId;

            serviceOrder = await _serviceOrderRepository.CreateAsync(serviceOrder);

            return serviceOrder.ToDTO();
        }

        public Task<bool> DeleteAsync(Guid userId, Guid publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShortServiceOrderDTO>> GetAllAsync(Guid userId)
        {
            var serviceOrders = await _serviceOrderRepository.GetAllByUserIdAsync(userId);

            return [.. serviceOrders.Select(so => so.ToShortDTO())];
        }

        public async Task<ServiceOrderDTO> GetByIdAsync(Guid userId, Guid publicId)
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(publicId);

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

            return serviceOrder.ToDTO();
        }

        public async Task<ServiceOrderDTO> RemoveImageAsync(
            Guid userId,
            RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                Guid.Parse(removeImageServiceOrderDTO.PublicId)
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

            await _imageStorageService.DeleteAsync(
                Path.Combine(
                    _storagePath,
                    serviceOrder.PublicId.ToString(),
                    removeImageServiceOrderDTO.ImageFileName!
                )
            );

            serviceOrder.ImageFiles.Remove(removeImageServiceOrderDTO.ImageFileName!);

            serviceOrder = await UpdateChangesAsync(
                serviceOrder.PublicId,
                null,
                null,
                serviceOrder.ImageFiles
            );

            return serviceOrder.ToDTO();
        }

        public async Task<ServiceOrderDTO> UpdateAsync(
            Guid userId,
            Guid publicId,
            UpdateServiceOrderDTO updateServiceOrderDTO
        )
        {
            var serviceOrder = await UpdateChangesAsync(
                publicId,
                updateServiceOrderDTO.Title,
                updateServiceOrderDTO.Description,
                null
            );

            return serviceOrder.ToDTO();
        }

        private async Task<ServiceOrder> UpdateChangesAsync(
            Guid publicId,
            string? title,
            string? description,
            List<string>? images
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(publicId);

            if (serviceOrder == null)
            {
                throw new Exception("Service order not found to update");
            }

            if (title != null)
            {
                serviceOrder.Title = title;
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
