﻿using HouseasyModel.DTO;

namespace HouseasyBusiness.TokenBusiness
{
    public interface ITokenBusiness
    {
        Task<LoginResponse> GerarToken(LoginResponse loginResposta);
    }
}
