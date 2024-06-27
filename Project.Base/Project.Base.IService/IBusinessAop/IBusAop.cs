using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.IService.IBusinessAop
{
    public interface IBusAop
    {
        Task Before(BusinessAopContext context);

        Task After(BusinessAopContext context);
    }
}
