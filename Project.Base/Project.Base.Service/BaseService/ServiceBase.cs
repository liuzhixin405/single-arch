using Project.Base.IRepository;
using Project.Base.Services;
using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Services
{
    public abstract class ServiceBase<TEntity,T> : IService where TEntity:class,IEntity<T>
    {
        protected readonly IRepository<TEntity, T> _repository;

        public ServiceBase(IRepository<TEntity, T> repository)
        {
            _repository = repository;
        }
        public abstract Task<ApiResult> AddAsync(IRequestDto requestDto) ;
        public abstract Task<ApiResult> UpdateAsync(IRequestDto requestDto) ;
        public abstract Task<ApiResult> DeleteAsyncc(IRequestDto requestDto) ;
        public abstract Task<ApiResult> GetPagedAsyncc(IRequestDto requestDto) ;
        public abstract Task<ApiResult> FindAsyncc(IRequestDto requestDto) ;
    }
}
