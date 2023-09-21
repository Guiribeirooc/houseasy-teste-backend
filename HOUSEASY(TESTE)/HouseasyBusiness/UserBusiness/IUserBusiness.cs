using HouseasyModel;

namespace HouseasyBusiness.UserBusiness
{
    public interface IUserBusiness
    {
        Task Incluir(User user);
        Task<User> ObterPorCPF(string cpf);
        Task<List<User>> ObterLista();
        Task Alterar(User cliente);
    }
}
