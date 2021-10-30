using System.Threading.Tasks;
using VanhackTest.Models.TokenAuth;
using VanhackTest.Web.Controllers;
using Shouldly;
using Xunit;

namespace VanhackTest.Web.Tests.Controllers
{
    public class HomeController_Tests: VanhackTestWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}