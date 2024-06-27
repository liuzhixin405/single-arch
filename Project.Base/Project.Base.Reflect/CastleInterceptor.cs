using Castle.DynamicProxy;
using Project.Base.Model;
using Project.Base.ProjAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Reflect
{
    public class CastleInterceptor : AsyncInterceptorBase
    {
        private List<BaseAopAttribute> _aops;
        private BusinessAopContext aopContext;
        private async Task Befor()
        {
            foreach (var aAop in _aops)
            {
                await aAop.Before(aopContext);
            }
        }
        private async Task After()
        {
            foreach (var aAop in _aops)
            {
                await aAop.After(aopContext);
            }
        }

        private void Init(IInvocation invocation)
        {
            aopContext = new ();

            _aops = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(BaseAopAttribute), true)
                .Concat(invocation.InvocationTarget.GetType().GetCustomAttributes(typeof(BaseAopAttribute), true))
                .Select(x => (BaseAopAttribute)x)
                .ToList();
        }

        protected override async Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            Init(invocation);

            await Befor();
            await proceed(invocation, proceedInfo);
            await After();
        }

        protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            Init(invocation);

            TResult result = default(TResult);

            await Befor();
            result = await proceed(invocation, proceedInfo);
            await After();
            return result;
        }
    }
}
