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

        public async Task UpdateUser(User user)
        {
            user.DataAlteracao = DateTime.Now;

            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task IncludeUser(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<User>> GetList()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetByCPF(string cpf)
        {
            return await _appDbContext.Users.SingleAsync(x => x.CPF == cpf);
        }
    }
}
