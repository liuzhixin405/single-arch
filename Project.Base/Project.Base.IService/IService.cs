using Autofac.Extras.DynamicProxy;
using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Services
{
    [Intercept("business-service log")]
    public interface IService
    {
       Task<ApiResult> AddAsync(IRequestDto requestDto);
       Task<ApiResult> UpdateAsync(IRequestDto requestDto);
       Task<ApiResult> DeleteAsyncc(IRequestDto requestDto);
       Task<ApiResult> GetPagedAsyncc(IRequestDto requestDto) ;
       Task<ApiResult> FindAsyncc(IRequestDto requestDto);
    }
}
