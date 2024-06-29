using ADM001_User.Model;
using ADM001_User.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project.Base.Common;
using Project.Base.Model;
using Project.Base.ProjController;
using Project.Base.Reflect;

namespace ADM001_User.Api
{
    public class ADM001_UserController : InitController<User>
    {
        private readonly IBusiness<IRequestDto> _business;
        public ADM001_UserController(ILogger<InitController<User>> logger) : base(logger)
        {
           _business = ServiceLocator.Instance.CreateAsyncScope().ServiceProvider.GetService<IBusiness<IRequestDto>>();
        }

        [HttpPost]
        public Task<ApiResult> Add(AddUserDto user)
        {
            return _business.AddAsync(user);
        }
    }
}
