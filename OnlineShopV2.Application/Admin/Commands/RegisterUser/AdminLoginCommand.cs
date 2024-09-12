using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class AdminLoginCommand : IRequest<string>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    public class TokenResponseModel
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
    }
}
