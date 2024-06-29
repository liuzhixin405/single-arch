using ADM001_User.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Base.IRepository;
using Project.Base.Module;
using Project.Base.Reflect;
using Project.Base.Repository;
using Project.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM001_User.Business
{
    public class UserModule : ModuleBase
    {

        public override void ConfigureService(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContext<UserDbContext>(options =>
       options.UseInMemoryDatabase("InMemoryDb"));

            services.AddScoped<IRepository<User, int>, GenericRepository<User,int,UserDbContext>>();
            services.AddTransient<IService, UserService>();

        }
    }
}
