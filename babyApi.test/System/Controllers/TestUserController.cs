using babyApi.test.MockData;
using Moq;
using babyApi.data.Repositories;
using babyApi.services.Interfaces;
using babyApi.services.Services;

namespace babyApi.test.System.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {

            var userRepositoryMock = new Mock<IUserRepository>();
            var IdToTest = 1;
            var nameToCheck = "Maria";

            userRepositoryMock.Setup(m => m.GetValideUsers(IdToTest)).Returns(Task.FromResult(GetAllUsersMockData.GetAll().Where(i => i.Id == IdToTest).ToList())).Verifiable();

            IUserService sut = new UserService(userRepositoryMock.Object);

 

            
            //Act
            var actual = await sut.GetValideUsers(IdToTest);

            //Assert
            userRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.NotNull(actual);//assert that a result was returned
            Assert.Equal(nameToCheck, actual.FirstOrDefault().Name);//assert that actual result was as expected

        }
    }
}