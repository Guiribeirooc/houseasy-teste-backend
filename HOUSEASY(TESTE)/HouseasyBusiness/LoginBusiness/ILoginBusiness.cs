using HouseasyModel.DTO;

namespace HouseasyBusiness.LoginBusiness
{
    public interface ILoginBusiness
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}