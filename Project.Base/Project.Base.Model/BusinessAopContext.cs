using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Model
{
    public class BusinessAopContext
    {
        /// <summary>
        /// 可以多个自取
        /// </summary>
        public object[] Parameters { get; set; }
        /// <summary>
        /// 执行之前返回结果
        /// </summary>
        public ApiResult BeforeResult { get; set; }
        /// <summary>
        /// 执行之后返回结果
        /// </summary>
        public ApiResult AfterResult { get; set; }
        /// <summary>
        /// 执行结果
        /// </summary>
        public ApiResult Result { get; set; }
        /// <summary>
        /// 特殊参数放这里
        /// </summary>
        public object[] Others { get; set; }
    }
}
