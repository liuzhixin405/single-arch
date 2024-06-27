using Project.Base.Model;
using System.Threading.Tasks;


namespace Project.Base.IServices
{
    public interface ICloseOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Close(TEntity entity);
        Task<ApiResult> UnClose(TEntity entity);

    }

}
