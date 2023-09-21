using HouseasyModel;

namespace HouseasyBusiness.UserBusiness
{
    public interface IUserBusiness
    {
        Task IncludeUser(User user);
        Task<User> GetByCPF(string cpf);
        Task<List<User>> GetList();
        Task UpdateUser(User cliente);
    }
}
