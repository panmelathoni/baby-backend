using babyApi.data.Repositories;
using babyApi.services.Interfaces;
using babyApi.services.Services;
using babyApi.test.MockData;
using Moq;

namespace babyApi.test.System.Controllers
{
    public class TestBabyProfileController
    {
       

        [Fact]
        public void BabyProfile_GetAll_ShouldReturnSuccess()
        {

            //Arrange - What do I need to bring in 
            var babyRepositoryMock = new Mock<IBabyProfileRepository>();           
            IBabyProfileService sut = new BabyProfileService(babyRepositoryMock.Object);

            //Act
            var result =  sut.GetAll();

            //Assert - Object check actions  
            babyRepositoryMock.Verify();
            Assert.Empty(result);
            Assert.NotNull(result);
           
        }
    }


}
 