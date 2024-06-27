using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.Base.ProjController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InitController<TModel>:ControllerBase
    {
        protected readonly ILogger<InitController<TModel>> _logger;
         public InitController(ILogger<InitController<TModel>> logger)
        {
            _logger = logger;

        }
      
    }
}
