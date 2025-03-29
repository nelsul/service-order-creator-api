using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceOrder> CreateAsync(ServiceOrder serviceOrder)
        {
            await _context.ServiceOrders.AddAsync(serviceOrder);

            await _context.SaveChangesAsync();

            return serviceOrder;
        }

        public Task<bool> DeleteAsync(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceOrder>> GetAllByUserIdAsync(string userId)
        {
            var serviceOrders = await _context
                .ServiceOrders.Where(so => so.UserId == userId)
                .ToListAsync();

            return serviceOrders;
        }

        public Task<ServiceOrder> GetByIdAsync(string guid)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrder> UpdateAsync(string guid, ServiceOrder serviceOrder)
        {
            throw new NotImplementedException();
        }
    }
}
