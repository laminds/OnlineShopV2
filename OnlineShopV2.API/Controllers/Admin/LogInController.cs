using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Admin.Commands.RegisterUser;
using OnlineShopV2.Application.Admin.Queries.GetUser;
using OnlineShopV2.Application.Common.Models;
using OnlineShopV2.Domain.IRepository;

namespace OnlineShopV2.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogInController : APIControllerBase
    {
        private readonly IMediator _mediator;
        ILoginRepository _loginRepository;

        public LogInController(IMediator mediator, ILoginRepository _loginRepository)
        {
            _mediator = mediator;
            this._loginRepository = _loginRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            ApiResponseModel<List<GetUser>> Response = new ApiResponseModel<List<GetUser>>();
            try
            {
                var user = await Mediator.Send(new GetUserQuery());
                Response.Data = user.ToList();
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
        public async Task<IActionResult> UserLogin(AdminLoginCommand obj)
        {
            ApiResponseModel<TokenResponseModel> Response = new ApiResponseModel<TokenResponseModel>();
            try
            {
                Response.Message = await this._loginRepository.CheckSignIn(obj.Username, obj.Password);
                if (Response.Message != "true")
                {
                    var token = await Mediator.Send(obj);
                    if (token == null)
                    {
                        Response.IsValid = false;
                        return Unauthorized();
                    }
                    Response.Data = new TokenResponseModel
                    {
                        Token = token,
                        Name = Response.Message
                    };
                    Response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                Response.IsValid = false;
                Response.Message = ex.Message;
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand obj)
        {
            ApiResponseModel<bool> Response = new ApiResponseModel<bool>();
            try
            {
                var createuser = await Mediator.Send(obj);
                Response.IsValid = true;
                Response.Message = createuser;
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
