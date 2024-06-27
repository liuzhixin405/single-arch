
using Project.Base.Model;

namespace Project.Base.IServices
{
    public interface IAddOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Add(TEntity entity);
    }
}
