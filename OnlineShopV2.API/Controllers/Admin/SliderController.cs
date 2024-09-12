using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Queries.GetCategory;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Application.Queries.GetSlider;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SliderController : APIControllerBase
    {
        private readonly IMediator mediator;
        ISliderRepository _insertSliderRepository;

        public SliderController(IMediator mediator, ISliderRepository insertSliderRepository)
        {
            this.mediator = mediator;
            this._insertSliderRepository = _insertSliderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliderList()
        {
            ApiResponseModel<List<GetSlider>> Response = new ApiResponseModel<List<GetSlider>>();
            try
            {
                var slider = await mediator.Send(new GetSliderQuery());
                Response.Data = slider.ToList();
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
        public async Task<IActionResult> UpsertSlider(InsertSliderCommand obj)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var Slider = await Mediator.Send(obj);
                Response.IsValid = true;
                Response.Message = Slider;
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSliderCommand command)
        {
            if (id != command.SliderId)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(long sliderId)
        {
            ApiResponseModel<string> Response = new ApiResponseModel<string>();
            try
            {
                var data = await Mediator.Send(new DeleteSliderCommand { SliderId = sliderId });
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
