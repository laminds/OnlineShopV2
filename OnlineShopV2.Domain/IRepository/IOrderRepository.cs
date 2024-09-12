using OnlineShopV2.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrderAsync();
        Task<OrderItem> GetOrderItemInfo(long orderid);
    }
}
