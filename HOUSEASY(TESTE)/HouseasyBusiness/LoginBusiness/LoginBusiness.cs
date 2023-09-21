﻿using HouseasyBusiness.TokenBusiness;
using HouseasyModel.DTO;

namespace HouseasyBusiness.LoginBusiness
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly ITokenBusiness _geradorTokenNegocio;
        public LoginBusiness(ITokenBusiness geradorTokenNegocio)
        {
            _geradorTokenNegocio = geradorTokenNegocio;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.Authenticated = false;
            loginResponse.User = loginRequest.User;
            loginResponse.Token = "";
            loginResponse.ExpirationDate = null;

            if (loginRequest.User == "UsuarioLocacao" && loginRequest.Password == "SenhaLocacao")
            {
                loginResponse = await _geradorTokenNegocio.GerarToken(loginResponse);
            }

            return loginResponse;
        }
    }
}