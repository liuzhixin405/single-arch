using Autofac.Extras.DynamicProxy;
using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.IService
{
    [Intercept("business-service log")]
    public interface IBusinessBase<TEntity> where TEntity : class
    {
        IBaseOperateServices<TEntity> OperateServices { get; set; }
        Task<ApiResult> Add(TEntity entity);
        Task<ApiResult> Update(TEntity entity);
        Task<ApiResult> IndependentUpdate(TEntity entity);
        Task<ApiResult> Delete(TEntity entity);
        Task<ApiResult> Audit(TEntity entity);
        Task<ApiResult> UnAudit(TEntity entity);
        Task<ApiResult> Submit(TEntity entity);
        Task<ApiResult> UnSubmit(TEntity entity);
        Task<ApiResult> Enable(TEntity entity);
        Task<ApiResult> UnEnable(TEntity entity);
        Task<ApiResult> Import(TEntity entity);
        Task<ApiResult> Export(TEntity entity);
        Task<ApiResult> Post(TEntity entity);
        Task<ApiResult> UnPost(TEntity entity);
        Task<ApiResult> Close(TEntity entity);
        Task<ApiResult> UnClose(TEntity entity);
        Task<ApiResult> CommonQuery(TEntity dto);
    }
}
