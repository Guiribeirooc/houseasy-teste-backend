using HouseasyBusiness.TokenBusiness;
using HouseasyModel.DTO;

namespace HouseasyBusiness.LoginBusiness
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly ITokenBusiness _tokenBusiness;
        public LoginBusiness(ITokenBusiness geradorTokenNegocio)
        {
            _tokenBusiness = geradorTokenNegocio;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.Authenticated = false;
            loginResponse.User = loginRequest.User;
            loginResponse.Token = "";
            loginResponse.ExpirationDate = null;

            if (loginRequest.User == "UserHouseasy" && loginRequest.Password == "PasswordHouseasy")
            {
                loginResponse = await _tokenBusiness.GenerateToken(loginResponse);
            }

            return loginResponse;
        }
    }
}
