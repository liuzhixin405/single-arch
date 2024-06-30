using ADM001_User.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Project.Base.IRepository;
using Project.Base.Module;
using Project.Base.Reflect;
using Project.Base.Repository;
using Project.Base.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM001_User.Business.Settings;
using Project.Base.Model;

namespace ADM001_User.Business
{
    public class UserModule : ModuleBase
    {

        public override void ConfigureService(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContext<UserDbContext>(options =>
       options.UseInMemoryDatabase("InMemoryDb"));

            services.AddScoped<IRepository<User, int>, GenericRepository<User, int, UserDbContext>>();
            services.AddTransient<IService, UserService>();

            AddMongo(services);
            AddMongoRepository<User, int>(services, "users");

        }


        private static IServiceCollection AddMongo(IServiceCollection services)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConenctionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });
            return services;
        }
        private static IServiceCollection AddMongoRepository<T, TID>(IServiceCollection services, string collectionName) where T : IEntity<TID>
        {
            services.AddSingleton<IRepository<User, int>>(serviceProvider =>
            {
                var db = serviceProvider.GetService<IMongoDatabase>();
                return new MongoRepository<User, int>(db, "collectionname");
            });
            return services;
        }
    }
}
