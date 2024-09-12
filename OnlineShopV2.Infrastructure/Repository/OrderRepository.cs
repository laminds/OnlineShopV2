using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {

        protected OnlineShopDbContext dbcontext;
        public OrderRepository(OnlineShopDbContext _db)
        {
            dbcontext = _db;
        }
        public async Task<List<Orders>> GetOrderAsync()
        {
            return await dbcontext.Orders.Where(c => c.IsDelete == false).ToListAsync();
        }
        public async Task<OrderItem> GetOrderItemInfo(long orderId)
        {
            return await dbcontext.OrderItem.Where(c => c.orderId == orderId).FirstOrDefaultAsync();
        }
    }
}
