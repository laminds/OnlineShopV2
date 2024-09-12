using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Commands.ProductReview;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Application.Admin.Queries.GetProductReview;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly IMediator mediator;
        private ICategoryRepository? categoryRepository;

        public ProductReviewController(IMediator mediator, ICategoryRepository categoryRepository)
        {
            this.mediator = mediator;
            this.categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductReviewList()
        {
            ApiResponseModel<List<ProductReviewList>> Response = new ApiResponseModel<List<ProductReviewList>>();
            try
            {
                var category = await mediator.Send(new GetProductReviewQuery());
                Response.Data = category.ToList();
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
        public async Task<IActionResult> GetProductReviewList(ProductReviewCommand obj)
        {
            ApiResponseModel<List<ProductReviewList>> Response = new ApiResponseModel<List<ProductReviewList>>();
            try
            {
                var productReviews = await mediator.Send(obj);
                Response.Data = productReviews.ToList();
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
        public async Task<IActionResult> ProductReviewApproved(ProductReviewApprovedCommand obj)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var data = await mediator.Send(new ProductReviewApprovedCommand { ProductReviewId = obj.ProductReviewId });
                Response.IsValid = true;
                Response.Message = data;
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
