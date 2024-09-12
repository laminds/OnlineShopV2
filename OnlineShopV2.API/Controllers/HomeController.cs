using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Queries.GetProducts;

namespace OnlineShopV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : APIControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductList()
        {
            var list = 2;
                //await Mediator.Send(new GetProductQuery());
            return Ok(list);
        }
    }
}
