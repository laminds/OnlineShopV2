using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Commands.Product;
using OnlineShopV2.Application.Admin.Queries.GetProduct;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private IProductRepository? productRepository;

        public ProductController(IMediator mediator, IProductRepository productRepository)
        {
            this.mediator = mediator;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            ApiResponseModel<List<ProductVm>> Response = new ApiResponseModel<List<ProductVm>>();
            try
            {
                var product = await mediator.Send(new GetProductQuery());
                Response.Data = product.ToList();
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
        public async Task<IActionResult> InsertProduct(InsertProductCommand obj)
        {
            ApiResponseModel<bool> Response = new ApiResponseModel<bool>();
            try
            {
                var product = await mediator.Send(obj);
                Response.IsValid = true;
                Response.Message = product;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
            }
            return Ok(Response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var data = await mediator.Send(new DeleteProductCommand { ProductId = id });
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