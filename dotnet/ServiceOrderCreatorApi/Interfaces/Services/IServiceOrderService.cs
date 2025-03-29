using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IServiceOrderService
    {
        Task<List<ServiceOrderDTO>> GetAllAsync();
    }
}
