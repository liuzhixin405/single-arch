using Project.Base.Model;
using System.Threading.Tasks;
namespace Project.Base.IServices
{
    public interface IQueryOperate<TEntity> where TEntity : class
    {
        Task<TEntity> QueryById(object objId);
        Task<ApiResult> CommonQuery<TEntity>(TEntity entity);

    }
}
