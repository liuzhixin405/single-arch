using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.ProjAttribute
{
    public abstract class BaseAopAttribute:Attribute
    {
        public virtual Task  Before(BusinessAopContext aopContext)
        {
            return Task.CompletedTask;
        }

        public virtual Task After(BusinessAopContext aopContext)
        {
            return Task.CompletedTask;
        }
    }
}
