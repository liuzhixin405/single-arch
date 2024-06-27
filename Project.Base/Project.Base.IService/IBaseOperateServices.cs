using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IService
{

    public interface IBaseOperateServices<T> :
        ICommOperate<T>
            where T : class
    {
        Task<T> QueryById(object objId);
        Task<ApiResult> Add(T entity);
        Task<ApiResult> Update(T entity);
        Task<ApiResult> IndependentUpdate(T entity);
        Task<ApiResult> Delete(T entity);
        Task<ApiResult> Audit(T entity);
        Task<ApiResult> UnAudit(T entity);
        Task<ApiResult> Submit(T entity);
        Task<ApiResult> UnSubmit(T entity);
        Task<ApiResult> Enable(T entity);
        Task<ApiResult> UnEnable(T entity);
        Task<ApiResult> Import(T entity);
        Task<ApiResult> Export(T entity);
        Task<ApiResult> Post(T entity);
        Task<ApiResult> UnPost(T entity);
        Task<ApiResult> Close(T entity);
        Task<ApiResult> UnClose(T entity);
        Task<ApiResult> CommonQuery(T entity);

    }
}
