using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces.Services
{
    public interface IServiceOrderTypeService
    {
        Task<ServiceOrderOptionsData> GenerateOrderOptions(int serviceTypeId);

        Task<bool> CheckOrderOptions(ServiceOrder serviceOrder);
    }
}
