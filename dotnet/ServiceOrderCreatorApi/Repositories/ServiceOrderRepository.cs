using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Data;
using ServiceOrderCreatorApi.Interfaces.Repositories;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public ServiceOrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<ServiceOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
