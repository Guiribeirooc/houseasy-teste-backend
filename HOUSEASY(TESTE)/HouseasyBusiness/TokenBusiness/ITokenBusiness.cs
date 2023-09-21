using HouseasyModel.DTO;

namespace HouseasyBusiness.TokenBusiness
{
    public interface ITokenBusiness
    {
        Task<LoginResponse> GenerateToken(LoginResponse loginResposta);
    }
}
