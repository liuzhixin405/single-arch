using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IServices
{
    public interface IPostOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Post(TEntity entity);
        Task<ApiResult> UnPost(TEntity entity);

    }
}
