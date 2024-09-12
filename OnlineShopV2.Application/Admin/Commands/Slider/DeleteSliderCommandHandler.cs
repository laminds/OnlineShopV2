using MediatR;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, string>
    {
        private readonly ISliderRepository _insertSliderRepository;
        public DeleteSliderCommandHandler(ISliderRepository insertSliderRepository)
        {
            _insertSliderRepository = insertSliderRepository;
        }
        public async Task<string> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            return await _insertSliderRepository.DeleteSlider(request.SliderId);
        }
    }
}
