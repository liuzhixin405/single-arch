﻿using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.IRepository
{
    public interface IRepository<TEntity,T> where TEntity : IEntity<T>
    {
        Task<ApiResult> AddAsync(TEntity entity);
        Task<ApiResult> UpdateAsync(TEntity entity);

        Task<ApiResult> DeleteAsync(Expression<Func<TEntity, bool>> filter);
        // 通用分页查询
        Task<PagedResult<TEntity>> GetPagedAsync(PagingParameters<TEntity> pagingParameters);

        // 其他常用操作
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);

    }
}