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

        public Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceOrder>> GetAllByUserIdAsync(Guid userId)
        {
            var serviceOrders = await _context
                .ServiceOrders.Where(so => so.UserId == userId.ToString())
                .ToListAsync();

            return serviceOrders;
        }

        public async Task<ServiceOrder?> GetByIdAsync(Guid Id)
        {
            var serviceOrder = await _context.ServiceOrders.FirstOrDefaultAsync(so => so.Id == Id);

            return serviceOrder;
        }

        public async Task<ServiceOrder> UpdateAsync(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Update(serviceOrder);

            await _context.SaveChangesAsync();

            return serviceOrder;
        }
    }
}
