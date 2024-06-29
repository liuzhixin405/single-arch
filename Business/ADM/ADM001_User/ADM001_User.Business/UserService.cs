using ADM001_User.Model;
using ADM001_User.Model.Dto;
using Project.Base.IRepository;
using Project.Base.Model;

using Project.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM001_User.Business
{
    public class UserService : ServiceBase<User, int>
    {
        public UserService(IRepository<User, int> repository) : base(repository)
        {

        }

        public override async Task<ApiResult> AddAsync(IRequestDto requestDto)
        {
            if (requestDto is AddUserDto userDto)
            {
                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password
                };
                return await _repository.AddAsync(user);
            }
            return new ApiResult { Success = false, Message = "Invalid DTO type"};
        }

        public override Task<ApiResult> DeleteAsyncc(IRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public override Task<ApiResult> FindAsyncc(IRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public override Task<ApiResult> GetPagedAsyncc(IRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public override Task<ApiResult> UpdateAsync(IRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
