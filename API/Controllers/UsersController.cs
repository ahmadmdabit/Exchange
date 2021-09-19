using API.Controllers.Abstraction;
using API.Helpers;
using API.Models;
using BLL;
using BLL.Abstraction;
using BLL.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseApiController<User>
    {
        public UsersController(IBusiness<User> _business, ILogger<BaseApiController<User>> logger) : base(_business, logger)
        {
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult<ApiResult<User>>> Authenticate(AuthenticateRequest model)
        {
            var response = await (this._business as UserBusiness).Authenticate(model).ConfigureAwait(false);

            if (response == null)
                return BadRequestApi("Username or password is incorrect");

            return Ok(response);
        }
    }
}