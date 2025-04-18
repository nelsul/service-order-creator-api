using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private readonly IServiceOrderTypeService _serviceOrderTypeService;
        private readonly IImageStorageService _imageStorageService;
        private readonly string _storagePath;

        public ServiceOrderService(
            IServiceOrderRepository serviceOrderRepository,
            IServiceOrderTypeService serviceOrderTypeService,
            IImageStorageService imageStorageService
        )
        {
            _serviceOrderRepository = serviceOrderRepository;
            _serviceOrderTypeService = serviceOrderTypeService;
            _imageStorageService = imageStorageService;
            _storagePath = "./storage/service-orders";
        }

        public async Task<ServiceOrderDTO> AddImageAsync(
            Guid userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                Guid.Parse(addImageServiceOrderDTO.Id)
            );

            if (serviceOrder == null)
            {
                throw new FileNotFoundException("Service Order not found");
            }

            if (serviceOrder.UserId != userId.ToString())
            {
                throw new UnauthorizedAccessException(
                    "Not uthorized to make changes to this service order"
                );
            }

            var fileName = await _imageStorageService.StoreAsync(
                Path.Combine(_storagePath, serviceOrder.Id.ToString()),
                addImageServiceOrderDTO.Image!
            );

            serviceOrder.ImageFiles.Add(fileName);

            serviceOrder = await UpdateChangesAsync(
                serviceOrder.Id,
                null,
                null,
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

            serviceOrder.Id = Guid.NewGuid();

            serviceOrder.UserId = userId.ToString();

            serviceOrder = await _serviceOrderRepository.CreateAsync(serviceOrder);

            return serviceOrder.ToDTO();
        }

        public Task<bool> DeleteAsync(Guid userId, Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShortServiceOrderDTO>> GetAllAsync(Guid userId)
        {
            var serviceOrders = await _serviceOrderRepository.GetAllByUserIdAsync(userId);

            return [.. serviceOrders.Select(so => so.ToShortDTO())];
        }

        public async Task<ServiceOrderDTO> GetByIdAsync(Guid userId, Guid Id)
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(Id);

            if (serviceOrder == null)
            {
                throw new FileNotFoundException("Service Order not found");
            }

            if (serviceOrder.UserId != userId.ToString())
            {
                throw new UnauthorizedAccessException(
                    "Not uthorized to make changes to this service order"
                );
            }

            return serviceOrder.ToDTO();
        }

        public async Task<byte[]> GetImageAsyc(
            Guid userId,
            RequestImageServiceOrderDTO requestImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                Guid.Parse(requestImageServiceOrderDTO.Id)
            );

            if (serviceOrder == null)
            {
                throw new FileNotFoundException("Service Order not found");
            }

            if (serviceOrder.UserId != userId.ToString())
            {
                throw new UnauthorizedAccessException(
                    "Not uthorized to make changes to this service order"
                );
            }

            var image = await _imageStorageService.GetAsync(
                Path.Combine(
                    _storagePath,
                    serviceOrder.Id.ToString(),
                    requestImageServiceOrderDTO.FileName!
                ),
                requestImageServiceOrderDTO.Width,
                requestImageServiceOrderDTO.Height
            );

            return image;
        }

        public async Task<ServiceOrderDTO> RemoveImageAsync(
            Guid userId,
            RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(
                Guid.Parse(removeImageServiceOrderDTO.Id)
            );

            if (serviceOrder == null)
            {
                throw new FileNotFoundException("Service Order not found");
            }

            if (serviceOrder.UserId != userId.ToString())
            {
                throw new UnauthorizedAccessException(
                    "Not uthorized to make changes to this service order"
                );
            }

            await _imageStorageService.DeleteAsync(
                Path.Combine(
                    _storagePath,
                    serviceOrder.Id.ToString(),
                    removeImageServiceOrderDTO.ImageFileName!
                )
            );

            serviceOrder.ImageFiles.Remove(removeImageServiceOrderDTO.ImageFileName!);

            serviceOrder = await UpdateChangesAsync(
                serviceOrder.Id,
                null,
                null,
                null,
                null,
                serviceOrder.ImageFiles
            );

            return serviceOrder.ToDTO();
        }

        public async Task<ServiceOrderDTO> UpdateAsync(
            Guid userId,
            Guid Id,
            UpdateServiceOrderDTO updateServiceOrderDTO
        )
        {
            var serviceOrder = await UpdateChangesAsync(
                Id,
                updateServiceOrderDTO.Title,
                updateServiceOrderDTO.Description,
                updateServiceOrderDTO.ServiceTypeId,
                updateServiceOrderDTO.Options,
                null
            );

            return serviceOrder.ToDTO();
        }

        private async Task<ServiceOrder> UpdateChangesAsync(
            Guid Id,
            string? title,
            string? description,
            int? serviceTypeId,
            ServiceOrderOptionsData? optionsData,
            List<string>? images
        )
        {
            var serviceOrder = await _serviceOrderRepository.GetByIdAsync(Id);

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

            if (serviceTypeId != null && serviceOrder.ServiceTypeId != serviceTypeId)
            {
                var newOptions = await _serviceOrderTypeService.GenerateOrderOptions(
                    (int)serviceTypeId
                );

                serviceOrder.ServiceTypeOptionsData = JsonSerializer.Serialize(newOptions);
                serviceOrder.ServiceTypeId = serviceTypeId;
            }

            if (optionsData != null)
            {
                serviceOrder.ServiceTypeOptionsData = JsonSerializer.Serialize(optionsData);

                await _serviceOrderTypeService.CheckOrderOptions(serviceOrder);
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
