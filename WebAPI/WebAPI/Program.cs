using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });
            builder.Services.AddDbContext<BoschContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BoschContext") ?? throw new InvalidOperationException("Connection string 'BoschContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors();


            //builder.Services.AddSingleton<IProductService, ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();

            //builder.Services.AddSingleton<ISubpieceService, SubpieceManager>();
            //builder.Services.AddSingleton<ISubpieceDal, EfSubpieceDal>();

            //builder.Services.AddSingleton<IProductSubpieceService, ProductSubpieceManager>();
            //builder.Services.AddSingleton<IProductSubpieceDal, EfProductSubpieceDal>();

            //builder.Services.AddSingleton<IDepartmentService, DepartmentManager>();
            //builder.Services.AddSingleton<IDepartmentDal, EfDepartmentDal>();

            //builder.Services.AddSingleton<IOrderService, OrderManager>();
            //builder.Services.AddSingleton<IOrderDal, EfOrderDal>();

            //builder.Services.AddSingleton<IOrderManufactureService, OrderManufactureManager>();

            //builder.Services.AddSingleton<IStationService, StationManager>();
            //builder.Services.AddSingleton<IStationDal, EfStationDal>();

            //builder.Services.AddSingleton<ISectionService, SectionManager>();
            //builder.Services.AddSingleton<ISectionDal, EfSectionDal>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}