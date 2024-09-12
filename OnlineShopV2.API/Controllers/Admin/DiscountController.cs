using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Commands.Discount;
using OnlineShopV2.Application.Admin.Queries.GetDiscount;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator? mediator;
        private readonly IDiscountRepository? discountRepository;

        public DiscountController(IMediator? mediator, IDiscountRepository? discountRepository)
        {
            this.mediator = mediator;
            this.discountRepository = discountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscountList()
        {
            ApiResponseModel<List<DiscountVm>> Response = new ApiResponseModel<List<DiscountVm>>();
            try
            {
                var Discount = await mediator.Send(new GetDiscountQuery());
                Response.Data = Discount.ToList();
                Response.IsValid = true;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertDiscount(InsertDiscountCommand obj)
        {
            ApiResponseModel<bool> Response = new ApiResponseModel<bool>();
            try
            {
                var Discount = await mediator.Send(obj);
                Response.IsValid = true;
                Response.Message = Discount;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var data = await mediator.Send(new DeleteDiscountCommand { discountId = id });
                Response.IsValid = true;
                Response.Message = data;
            }
            catch(Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }
    }
}
