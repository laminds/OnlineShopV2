using AutoMapper;
using MediatR;
using OnlineShopV2.Application.Admin.Commands.Product;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands.Order
{
    public class GetOrderItemInfoCommandHandler : IRequestHandler<GetOrderItemInfoCommand, OrderItem>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderItemInfoCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository; 
        }
        public async Task<OrderItem> Handle(GetOrderItemInfoCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderItemInfo(request.orderId);
        }
    }
}