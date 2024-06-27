using Project.Base.Model;
using System.Threading.Tasks;


namespace Project.Base.IServices
{
    public interface IAuditOperate<TEntity> where TEntity : class
    {
        Task<ApiResult> Audit(TEntity entity );
        Task<ApiResult> UnAudit(TEntity entity);

    }
}
