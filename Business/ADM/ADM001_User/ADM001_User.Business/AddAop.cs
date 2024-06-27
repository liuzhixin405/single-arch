using Project.Base.Model;
using Project.Base.ProjAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM001_User.Business
{
    /// <summary>
    /// 有需要就实现前后动作
    /// </summary>
    public class AddAop: BaseAopAttribute
    {
        public override Task After(BusinessAopContext aopContext)
        {
            return Task.CompletedTask;
        }

        public override Task Before(BusinessAopContext aopContext)
        {
            return Task.CompletedTask;
        }
    }
}
