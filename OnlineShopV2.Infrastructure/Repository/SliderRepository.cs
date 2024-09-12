using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopV2.Domain.EntityModels;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure.Data;
using OnlineShopV2.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShopV2.Infrastructure.Repository
{
    public class SliderRepository : ISliderRepository
    {
        protected OnlineShopDbContext _context;
        public SliderRepository(OnlineShopDbContext onlineShopDbContext)
        {
            _context = onlineShopDbContext;
        }

        public async Task<List<Slider>> GetSliderList()
        {
            return await _context.Slider.ToListAsync();
        }
         
        public async Task<string> InsertSliderInfo(Slider slider)
        {
            try
            {
                if(slider.SliderId != null)
                {
                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertSliderInfo]  @SliderId = {0}, @Image = {1}, @Title = {2}, @RedirectURL = {5}, @IsActive = {7}, @CreatedBy = {8}",
                             slider.SliderId, slider.Image, slider.Title,  slider.RedirectUrl, slider.IsActive, slider.CreatedBy);
                    return result.ToString();
                }
                else 
                {
                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_InsertSliderInfo] @Guid = {0}, @Image = {1}, @Title = {2}, @RedirectURL = {5},  @IsActive = {7}, @CreatedBy = {8}", slider.Guid, slider.Image, slider.Title, slider.Description, slider.RedirectUrl, slider.IsActive, slider.CreatedBy);
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public async Task<string> DeleteSlider(long id)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC [admin].[usp_DeleteSliderInfo] @SliderID = {0}", id);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}