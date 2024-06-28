using ADM001_User.Model;
using Project.Base.IService;
using Project.Base.Model;
using Project.Base.Reflect;

namespace ADM001_User.Business
{
    public class ADM001_UserBusiness : IBusiness<User>
    {
        //private readonly IBusinessBase<User> _businessBase;
        //public ADM001_UserBusiness(IBusinessBase<User> businessBase)
        //{
        //    _businessBase = businessBase;
        //}
        [AddAop]
        public Task<ApiResult> Add(User entity)
        {
            return Task.FromResult(new ApiResult() { Success = true,  Status=200 });
        }

        public Task<ApiResult> Audit(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Close(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Enable(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Export(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Import(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Post(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Submit(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UnAudit(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UnClose(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UnEnable(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UnPost(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> UnSubmit(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
