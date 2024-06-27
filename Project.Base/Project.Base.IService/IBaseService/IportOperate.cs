using Project.Base.Model;
using System.Threading.Tasks;


namespace Project.Base.IServices
{
    public interface IportOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Import(TEntity entity);
        Task<ApiResult> Export(TEntity entity);

    }
}
