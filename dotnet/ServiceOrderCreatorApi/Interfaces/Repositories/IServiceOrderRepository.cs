using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Interfaces.Repositories
{
    public interface IServiceOrderRepository
    {
        Task<List<ServiceOrder>> GetAllAsync();
    }
}
