using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands.Order;
using OnlineShopV2.Application.Admin.Queries.GetOrder;
using OnlineShopV2.Application.Admin.Queries.GetProduct;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Application.Queries.GetSlider;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator, ICategoryRepository categoryRepository)
        {
            this.mediator = mediator;
            //this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            ApiResponseModel<List<GetOrder>> Response = new ApiResponseModel<List<GetOrder>>();
            try
            {
                var order = await mediator.Send(new GetOrderQuery());
                Response.Data = order.ToList();
                Response.IsValid = true;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItemInfo(long orderId)
        {
            ApiResponseModel<OrderItem> Response = new ApiResponseModel<OrderItem>();
            try
            {
                var order = await mediator.Send(new GetOrderItemInfoCommand() { orderId = orderId });
                Response.Data = order;
                Response.IsValid = true;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }
    }
}
