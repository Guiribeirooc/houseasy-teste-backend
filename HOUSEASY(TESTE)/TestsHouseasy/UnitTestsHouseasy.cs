using HouseasyAPI.Controllers;
using HouseasyBusiness.UserBusiness;
using HouseasyModel;
using Moq;

namespace TestsHouseasy
{
    public class UnitTestsHouseasy
    {
        [Fact]
        public async Task UserSuccessfullyRegistered()
        {
            var user = new User
            {
                CPF = "111.222.333-44",
                Nome = "Guilherme Rodrigues",
                Ocupacao = "Desenvolvedor .NET",
                DataNascimento = DateTime.Now,
                Telefone = "",
                Celular = "(11) 91234-5678",
                Email = "guilherme@gmail.com",
                CEP = "08745-250",
                Logradouro = "Rua São Francisco",
                Numero = "121",
                Complemento = "",
                Bairro = "Vila Bela Flor",
                Cidade = "Mogi das Cruzes",
                Estado = "SP",
                DataAlteracao = DateTime.Now,
                DataInclusao = DateTime.Now
            };

            var mockData = new Mock<IUserBusiness>();
            mockData.Setup(data => data.IncludeUser(It.IsAny<User>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new UsersController(mockData.Object);

            await controller.Include(user);

            mockData.Verify(x => x.IncludeUser(It.IsAny<User>()), Times.Once());
        }

        [Fact]
        public async Task ChangeUserRegistration()
        {
            var user = new User
            {
                CPF = "111.222.333-44",
                Nome = "Patricia Rodrigues",
                Telefone = "",
                Celular = "(11) 91234-5678",
                Email = "patricia@gmail.com",
                CEP = "08738-260",
                Logradouro = "Rua Jose Beneditos dos Santos",
                Numero = "261",
                Bairro = "Vila Brasileira",
                Cidade = "Mogi das Cruzes",
                Estado = "SP",
            };

            var mockData = new Mock<IUserBusiness>();
            mockData.Setup(data => data.UpdateUser(It.IsAny<User>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new UsersController(mockData.Object);

            await controller.Put(user);

            mockData.Verify(x => x.UpdateUser(It.IsAny<User>()), Times.Once());
        }

        [Fact]
        public async Task GetUsersByCPFSuccess()
        {
            string cpf = "444.333.222-11";
            var user = new User
            {
                CPF = "444.333.222-11",
                Nome = "Guilherme Rodrigues",
                Ocupacao = "Desenvolvedor .NET",
                DataNascimento = DateTime.Now,
                Telefone = "",
                Celular = "(11) 91234-5678",
                Email = "guilherme@gmail.com",
                CEP = "08745-250",
                Logradouro = "Rua São Francisco",
                Numero = "121",
                Complemento = "",
                Bairro = "Vila Bela Flor",
                Cidade = "Mogi das Cruzes",
                Estado = "SP",
                DataAlteracao = DateTime.Now,
                DataInclusao = DateTime.Now
            };

            var mockData = new Mock<IUserBusiness>();
            mockData.Setup(data => data.GetByCPF(It.IsAny<string>()))
                .Returns(Task.FromResult(user))
                .Verifiable();
            var controller = new UsersController(mockData.Object);

            await controller.GetByCPF(cpf);

            mockData.Verify(x => x.GetByCPF(cpf), Times.Once());
        }

        [Fact]
        public async Task GetListUsersSuccess()
        {
            var users = new List<User>
            {
                new User { CPF = "111.222.333-44"},
                new User { CPF = "222.333.444-55"},
                new User { CPF = "333.444.555-66"},
                new User { CPF = "444.555.666-77"},
            };

            var mockData = new Mock<IUserBusiness>();
            mockData.Setup(data => data.GetList())
                .Returns(Task.FromResult(users))
                .Verifiable();
            var controller = new UsersController(mockData.Object);

            await controller.Get();

            mockData.Verify(x => x.GetList(), Times.Once());
        }

        [Fact]
        public async Task DeleteUserSuccess()
        {
            string cpf = "444.333.222-11";
            var user = new User
            {
                CPF = "444.333.222-11",
                Nome = "Guilherme Rodrigues",
                Ocupacao = "Desenvolvedor .NET",
                DataNascimento = DateTime.Now,
                Telefone = "",
                Celular = "(11) 91234-5678",
                Email = "guilherme@gmail.com",
                CEP = "08745-250",
                Logradouro = "Rua São Francisco",
                Numero = "121",
                Complemento = "",
                Bairro = "Vila Bela Flor",
                Cidade = "Mogi das Cruzes",
                Estado = "SP",
                DataAlteracao = DateTime.Now,
                DataInclusao = DateTime.Now
            };

            var mockData = new Mock<IUserBusiness>();
            mockData.Setup(data => data.RemoveUser(It.IsAny<string>()))
                .Returns(Task.FromResult(user))
                .Verifiable();
            var controller = new UsersController(mockData.Object);

            await controller.Remove(cpf);

            mockData.Verify(x => x.RemoveUser(cpf), Times.Once());
        }
    }
}