using Microsoft.EntityFrameworkCore;
using NetAcademy.DataBase;
using NetAcademy.Services.Abstractions;
using NetAcademy.Services.Implementation;

namespace NetAcademy.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BookStoreDbContext>(opt =>
                opt.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=book-store-db;Trusted_Connection=True;MultipleActiveResultSets=true"));


            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();
            builder.Services.AddScoped<ITest1Service, Test1Service>();
            builder.Services.AddScoped<ITest2Service, Test2Service>();
            builder.Services.AddTransient<ITransientService, TransientService>();
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddSingleton<ISingletonService, SingletonService>();

            var app = builder.Build();

            //Use Map Run 
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
