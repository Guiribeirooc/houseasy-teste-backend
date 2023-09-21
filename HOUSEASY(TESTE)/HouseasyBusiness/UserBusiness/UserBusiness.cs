using HouseasyModel;
using HouseasyInfra.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HouseasyBusiness.UserBusiness
{
    public class UserBusiness : IUserBusiness
    {
        private readonly AppDbContext _appDbContext;
        public UserBusiness(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Alterar(User user)
        {
            user.DataAlteracao = DateTime.Now;

            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Incluir(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<User>> ObterLista()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> ObterPorCPF(string cpf)
        {
            return await _appDbContext.Users.SingleAsync(x => x.CPF == cpf);
        }
    }
}
