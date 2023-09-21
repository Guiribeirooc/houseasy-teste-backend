using HouseasyBusiness.UserBusiness;
using HouseasyModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task Include([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                await _userBusiness.IncludeUser(user);
            }
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _userBusiness.GetList();
        }

        [HttpGet("GetByCPF")]
        public async Task<User> GetByCPF([FromQuery] string cpf)
        {
            return await _userBusiness.GetByCPF(cpf);
        }

        [HttpPut]
        public async Task Put([FromBody] User user)
        {
            if (ModelState.IsValid)
                await _userBusiness.UpdateUser(user);
        }
    }
}
