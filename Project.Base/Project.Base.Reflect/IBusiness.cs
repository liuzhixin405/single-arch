using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Reflect
{
 
        /// <summary>
        /// 业务层约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IBusiness<T> where T : class
        {
            Task<ApiResult> AddAsync(T entity);
           
        }
}
