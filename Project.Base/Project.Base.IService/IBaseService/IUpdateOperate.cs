using Project.Base.Model;
using System.Threading.Tasks;

namespace Project.Base.IServices
{
    public interface IUpdateOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Update(TEntity entity );
        Task<ApiResult> IndependentUpdate(TEntity entity );


    }
}
