using test.Entity.Entities;
using test.Infrastructure.Dtos.JwtDto;

namespace test.Infrastructure.CQRS.Handler.TokenHandler
{

    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(Login login);
    }
}
