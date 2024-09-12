using AutoMapper;
using MediatR;
using OnlineShopV2.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopV2.Application.Queries.GetSlider
{
    public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery, List<GetSlider>>
    {
        private readonly ISliderRepository _insertSliderRepository;
        private readonly IMapper _mapper;
        public GetSliderQueryHandler(ISliderRepository insertSliderRepository , IMapper mapper)
        {
            _insertSliderRepository = insertSliderRepository;
            _mapper = mapper;
        }
        public async Task<List<GetSlider>> Handle(GetSliderQuery request, CancellationToken cancellationToken)
        {
            var sliders =  await _insertSliderRepository.GetSliderList();
            //var sliderlist =  sliders.Select(x => new GetSlider
            //{
            //    Image = x.Image,
            //    Title = x.Title,
            //    Description = x.Description,
            //    OrderNo = (int)x.OrderNo,
            //    RedirectUrl = x.RedirectUrl,
            //    CategoryId = x.CategoryId,
            //    IsActive = x.IsActive
            //}).ToList();
            var sliderlist = _mapper.Map<List<GetSlider>>(sliders);
            return sliderlist;
        }
    }
}
