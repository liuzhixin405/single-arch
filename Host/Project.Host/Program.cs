
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Project.Base.Reflect;
using System.Reflection;
namespace Project.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().ConfigureApplicationPartManager(apm => {

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "bus_lib");
                var serviceList = (builder.Configuration.GetSection("ServiceList").Get<string[]>()) ?? new string[] { "ADM" };//默认加载基础服务
                string[] serviceFiles = Directory.GetFiles(folder, "*.Api.dll").Where(x =>
                    serviceList.Any(y => x.Contains(y))
                ).ToArray();

                foreach (var file in serviceFiles)
                {
                    if (File.Exists(file))
                    {
                        var assembly = Assembly.LoadFrom(file);
                        var controllerAssemblyPart = new AssemblyPart(assembly);
                        apm.ApplicationParts.Add(controllerAssemblyPart);
                    }
                }
            }); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddBusinessServices();
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
