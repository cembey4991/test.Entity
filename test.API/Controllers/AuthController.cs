using Microsoft.AspNetCore.Mvc;
using test.Entity.Entities;
using test.Infrastructure.Dtos.JwtDto;
using TokenHandler = test.Infrastructure.CQRS.Handler.TokenHandler.TokenHandler;

namespace test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost("[action]")]
        public async Task<TokenDto> Login([FromForm] Login login)
        {

            if (login.UserName == Test().UserName && login.Password == Test().Password)
            {

                TokenHandler tokenHandler = new(_configuration);
                TokenDto token = tokenHandler.CreateAccessToken(login);


                return token;

            }
            return null;
        }

        [NonAction]
        public Login Test()
        {
            Login model = new()
            {
                UserName = "cem",
                Password = "123"
            };
            return model;
        }
    }
}
