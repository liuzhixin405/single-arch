using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Model
{
    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T Response { get; set; }
        public static ApiResult<T> SuccessResult(T data=default(T))
        {
            return new ApiResult<T> { Success = true, Response = data ,Status=200};
        }

        public static ApiResult<T> FailResult(string message, int status=400)
        {
            return new ApiResult<T> { Success = false ,Message=message, Status=status};
        }
    }
    public class ApiResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; } = "";
      
        /// <summary>
        /// 是否调用下个接口
        /// </summary>
        public string Nexturl { get; set; }
        /// <summary>
        /// 多语言映射集合
        /// </summary>
        public Dictionary<string, object> Mapper
        {
            get; set;
        }
    }
}
