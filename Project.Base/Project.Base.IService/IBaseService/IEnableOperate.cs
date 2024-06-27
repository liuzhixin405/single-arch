using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IServices
{
    public interface IEnableOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Enable(TEntity entity);
        Task<ApiResult> UnEnable(TEntity entity);


    }
}
