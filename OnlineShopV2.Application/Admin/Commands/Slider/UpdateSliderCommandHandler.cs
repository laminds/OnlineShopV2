using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, string>
    {
        private readonly ISliderRepository _insertSliderRepository;
        public UpdateSliderCommandHandler(ISliderRepository insertSliderRepository)
        {
            _insertSliderRepository = insertSliderRepository;
        }
        public async Task<string> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var UpdateSlider = new Slider()
            {
                SliderId = request.SliderId,
                Image = request.Image,
                Title = request.Title,    
                RedirectUrl = request.RedirectUrl,
                IsActive = (bool)request.IsActive,
                CreatedBy = request.CreatedBy,
            };

            return await _insertSliderRepository.InsertSliderInfo(UpdateSlider);
        }
    }
}
