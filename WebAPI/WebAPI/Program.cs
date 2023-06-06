using Business.Abstract;
using Business.Concrete;
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
            builder.Services.AddDbContext<BoschContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BoschContext") ?? throw new InvalidOperationException("Connection string 'BoschContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IProductService, ProductManager>();
            builder.Services.AddSingleton<IProductDal, EfProductDal>();
            builder.Services.AddSingleton<ISubpieceService, SubpieceManager>();
            builder.Services.AddSingleton<ISubpieceDal, EfSubpieceDal>();
            builder.Services.AddSingleton<IProduct_SubpieceService, Product_SubpieceManager>();
            builder.Services.AddSingleton<IProduct_SubpieceDal, EfProduct_SubpieceDal>();
            builder.Services.AddSingleton<IDepartmentService, DepartmentManager>();
            builder.Services.AddSingleton<IDepartmentDal, EfDepartmentDal>();
            builder.Services.AddSingleton<IOrderService, OrderManager>();
            builder.Services.AddSingleton<IOrderDal, EfOrderDal>();
            builder.Services.AddSingleton<IStationOrderService, AStationManager>();
            builder.Services.AddSingleton<IStationOrderService, BStationManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}