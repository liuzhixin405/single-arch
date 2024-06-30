using ADM001_User.Model;
using ADM001_User.Model.Dto;
using Microsoft.Extensions.DependencyInjection;
using Project.Base.Common;
using Project.Base.Model;
using Project.Base.Reflect;
using Project.Base.Services;

namespace ADM001_User.Business
{
    public class ADM001_UserBusiness : IBusiness<IRequestDto>
    {
        [AddAop]
        public Task<ApiResult> AddAsync(IRequestDto entity)
        {
            var service = ServiceLocator.Instance.CreateAsyncScope().ServiceProvider.GetService<IService> ();
            return service.AddAsync(entity);
        }

      
    }
}
