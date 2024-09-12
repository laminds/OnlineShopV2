using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class DeleteSliderCommand : IRequest<string>
    {
        public long SliderId { get; set; }
    }
}
