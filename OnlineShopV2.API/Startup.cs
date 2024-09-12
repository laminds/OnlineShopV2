using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using OnlineShopV2.API;
using OnlineShopV2.Application;
using OnlineShopV2.Application.Admin.Commands;
using OnlineShopV2.Application.Common.Mappings;
using OnlineShopV2.Domain.IRepository;
using OnlineShopV2.Infrastructure;
using OnlineShopV2.Infrastructure.Repository;

namespace OnlineShopV2.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services) {

            // Add layer dependency
            services.AddApplicationServices();
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);

            services.AddControllers();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            RegisterDI(services);

            RegisterCors(services);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();
      
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHangfireDashboard();
            });


        }

        private void RegisterCors(IServiceCollection services)
        {
            var webUrl = Configuration.GetSection("Urls:FrontEnd").Value;
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder
                    .WithOrigins("http://localhost:4200")
                    //.SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    );
            });
        }

        private static void RegisterDI(IServiceCollection services)
        {
            RegisterRepositories(services);
        }
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, AdminLoginRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
        }
        private static void RegisterHandler(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AdminLoginCommand, string>, AdminLoginCommandHandler>();
            services.AddTransient<IRequestHandler<InsertSliderCommand, string>, InsertSliderCommandHandler>();
        }
    }
}
