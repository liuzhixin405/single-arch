using MongoDB.Driver;
using Project.Base.IRepository;
using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Repository
{
    public class MongoRepository<T,TID> : IRepository<T, TID> where T : class, IEntity<TID>
    {
        private readonly IMongoCollection<T> dbCollection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;
        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            dbCollection = database.GetCollection<T>(collectionName);
        }
        public async Task<ApiResult> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
            return new ApiResult();
        }

        public async Task<ApiResult> DeleteAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
           throw new NotImplementedException("请使用DeleteAsync(TID id)方法");
        }

        public async Task<ApiResult> DeleteAsync(TID id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
            return new ApiResult();
        }

        public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            var result = await dbCollection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<PagedResult<T>> GetPagedAsync(PagingParameters<T> pagingParameters)
        {
            Expression<Func<T, bool>> filter = x => true;
            //todo: 实现分页
            var query  =await dbCollection.Find(filter).ToListAsync();
            return new PagedResult<T> { };
        }

        public async Task<ApiResult> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
            return new ApiResult();
        }
    }
}
