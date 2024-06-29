
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Project.Base.Reflect;
using System.Reflection;
using Project.Base.ProjExtension;
using Project.Base.Common;
using Project.Base.DependencyInjection;
using Project.Base.Module;
namespace Project.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            builder.Configuration.AddJsonFile("appsettings.Modules.json", optional: false, reloadOnChange: true);
            //IModuleע�� ,Ȼ��ɨ�����ConfigureService��Businessע����Ҫ�ķ������
            builder.Services.InitModule(builder.Configuration);
            var sp = builder.Services.BuildServiceProvider();
            var moduleInitializers = sp.GetServices<IModule>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.ConfigureService(builder.Services, builder.Configuration);
            }
            // Add services to the container.
            var assemblys = GolbalConfiguration.Modules.Select(x => x.Assembly).ToList();


            var mvcBuilder=builder.Services.AddControllers().ConfigureApplicationPartManager(apm => {

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "bus_lib");
                var serviceList = (builder.Configuration.GetSection("ServiceList").Get<string[]>()) ?? new string[] { "ADM" };//Ĭ�ϼ��ػ�������
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
            });
            foreach (var assembly in assemblys)
            {
                // ɨ�貢ע�����������еĿ�����
                mvcBuilder.AddApplicationPart(assembly);
                // ɨ�貢ע�����������еķ���   �������ע��
                builder.Services.ReisterServiceFromAssembly(assembly);
            } 

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddBusinessServices();

            var app = builder.Build();
            ServiceLocator.Instance = app.Services;

            //imodule ��Configure����,business����ʵ���м���Ȳ���
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, app.Environment);
            }
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
