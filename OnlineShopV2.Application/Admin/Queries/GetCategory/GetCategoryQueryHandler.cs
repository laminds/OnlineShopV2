using AutoMapper;
using MediatR;
using OnlineShopV2.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Application.Queries.GetSlider;
using OnlineShopV2.Domain.EntityModels;

namespace OnlineShopV2.Application.Admin.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryRepository  categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;


        }
        public  async Task<List<CategoryVm>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoryAsync();

            var sliderlist = _mapper.Map<List<CategoryVm>>(list);
            return sliderlist;

        }
    }
}
