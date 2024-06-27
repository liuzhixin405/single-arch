using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IServices
{
    public interface IDeleteOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Delete(TEntity entity);
    }
}
