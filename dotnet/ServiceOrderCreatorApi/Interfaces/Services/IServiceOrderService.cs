using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IServiceOrderService
    {
        Task<List<ShortServiceOrderDTO>> GetAllAsync(string userId);

        Task<ServiceOrderDTO> GetByIdAsync(string userId, string guid);

        Task<bool> CreateAsync(CreateServiceOrderDTO createServiceOrderDTO);

        Task<ServiceOrderDTO> UpdateAsync(
            string userId,
            string guid,
            UpdateServiceOrderDTO updateServiceOrderDTO
        );

        Task<bool> DeleteAsync(string userId, string guid);

        Task<ServiceOrderDTO> AddImageAsync(
            string userId,
            AddImageServiceOrderDTO addImageServiceOrderDTO
        );

        Task<ServiceOrderDTO> RemoveImageAsync(
            string userId,
            RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        );
    }
}
