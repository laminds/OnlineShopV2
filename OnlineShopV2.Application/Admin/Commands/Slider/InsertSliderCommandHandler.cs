using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopV2.Application.Admin.Commands
{
    public class InsertSliderCommandHandler : IRequestHandler<InsertSliderCommand, string>
    {
        private readonly ISliderRepository _insertSliderRepository;
        private readonly IMapper _mapper;
        private readonly OnlineShopDbContext _context;

        public InsertSliderCommandHandler(ISliderRepository insertSliderRepository , IMapper mapper, OnlineShopDbContext context)
        {
            _insertSliderRepository = insertSliderRepository;
            _mapper = mapper;
            _context = context;
        }


        public async Task<string> Handle(InsertSliderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int SliderId;
                if (request.SliderId == null || request.SliderId == 0)
                {
                    var obj = new Slider()
                    {
                        Guid = Guid.NewGuid(),
                        Image = request.Image,
                        Title = request.Title,
                        Description = request.Description,
                        RedirectUrl = request.RedirectUrl,
                        IsActive = (bool)request.IsActive,
                        CreatedBy = request.CreatedBy,
                        CreatedOn = DateTime.UtcNow

                    };
                    _context.Slider.Add(obj);
                    await _context.SaveChangesAsync(cancellationToken);
                    return "Insert";
                }
                else
                {
                    var slider = await _context.Slider.FindAsync(request.SliderId);
                    slider.Image = request.Image;
                    slider.Title = request.Title;
                    slider.Description = request.Description;
                    slider.RedirectUrl = request.RedirectUrl;
                    slider.IsActive = (bool)request.IsActive; // Preserve existing value if not provided
                    slider.ModifiedBy = request.ModifiedBy;
                    slider.ModifiedOn = DateTime.UtcNow;

                    _context.Slider.Update(slider);
                    await _context.SaveChangesAsync(cancellationToken);
                    return "update";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            //var Result = await _insertSliderRepository.InsertSliderInfo(obj);
            //return _mapper.Map<string>(Result);
            //return await _insertSliderRepository.InsertSliderInfo(obj);
        }   
    }
}
