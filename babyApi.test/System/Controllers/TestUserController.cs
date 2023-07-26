using babyApi.test.MockData;
using Microsoft.AspNet.Identity;
using Moq;
using babyApi.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace babyApi.test.System.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            var user = new Mock<IUser>();
            user.Setup(_ => _.GetAll()).ReturnsAsync(GetAllUsersMockData.GetAll());

            var sut = new TestUserController(user.Object);

            var result = (OkObjectResult)await sut.GetAll();

            result.StatusCode.Should().Be(200);

        }
    }
}
