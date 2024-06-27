using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IServices
{
    public interface ISubmitOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Submit(TEntity entity );
        Task<ApiResult> UnSubmit(TEntity entity );
    }
}
