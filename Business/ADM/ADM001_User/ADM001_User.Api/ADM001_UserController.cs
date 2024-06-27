using ADM001_User.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Base.Model;
using Project.Base.ProjController;
using Project.Base.Reflect;

namespace ADM001_User.Api
{
    public class ADM001_UserController : InitController<User>
    {
        private readonly IBusiness<User> _business;
        public ADM001_UserController(IBusiness<User> business,ILogger<InitController<User>> logger) : base(logger)
        {
            _business = business;
        }

        [HttpPost]
        public Task<ApiResult> Add(User user)
        {
            return _business.Add(user);
        }
    }
}
