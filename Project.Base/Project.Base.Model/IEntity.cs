using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Model
{
    /// <summary>
    /// 实体标记
    /// </summary>
    public  interface IEntity<T>
    {
        T Id { get; set; }
    }
}
