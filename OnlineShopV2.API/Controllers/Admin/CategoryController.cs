using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Commands.Category;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private ICategoryRepository? categoryRepository;

        public CategoryController(IMediator mediator, ICategoryRepository categoryRepository)
        {
            this.mediator = mediator;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            ApiResponseModel<List<CategoryVm>> Response = new ApiResponseModel<List<CategoryVm>>();
            try
            {
                var category = await mediator.Send(new GetCategoryQuery());
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
        public async Task<IActionResult> InsertCategory(InsertCategoryCommand obj)
        {
            ApiResponseModel<bool> Response = new ApiResponseModel<bool>();
            try
            {
                //obj.CategoryId = 128;
                var category = await mediator.Send(obj);
                Response.IsValid = true;
                Response.Message = category;
            } 
            catch (Exception ex) {
                Response.IsValid = false;   
            }
            return Ok(Response);  
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommand command)
        {
            if (id != command.CategoryId)
            {
                return BadRequest();
            }
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var data = await mediator.Send(new DeleteCategoryCommand { SliderId = id });
                Response.IsValid = true;
                Response.Message = data;
            }
            catch (Exception ex) {
                Response.IsValid = false;
                Response.Message = ex.Message;
            } 
            return Ok(Response);
        }

    }
}