using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Base.Model;

namespace Project.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("/login")]
        public Task<ApiResult> Login(string username, string password)
        {
            return Task.FromResult(new ApiResult { Status = 200, Success = true, Message = "Login success" });
        }

    }
}
