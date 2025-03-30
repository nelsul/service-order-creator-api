using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IServiceOrderService
    {
        Task<List<ShortServiceOrderDTO>> GetAllAsync(Guid userId);

        Task<ServiceOrderDTO> GetByIdAsync(Guid userId, Guid Id);

        Task<ServiceOrderDTO> CreateAsync(Guid userId, CreateServiceOrderDTO createServiceOrderDTO);

        Task<ServiceOrderDTO> UpdateAsync(
            Guid userId,
            Guid Id,
            UpdateServiceOrderDTO updateServiceOrderDTO
        );

        Task<bool> DeleteAsync(Guid userId, Guid Id);

        Task<ServiceOrderDTO> AddImageAsync(
            Guid userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        );

        Task<ServiceOrderDTO> RemoveImageAsync(
            Guid userId,
            RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        );

        Task<byte[]> GetImageAsyc(
            Guid userId,
            RequestImageServiceOrderDTO requestImageServiceOrderDTO
        );
    }
}
