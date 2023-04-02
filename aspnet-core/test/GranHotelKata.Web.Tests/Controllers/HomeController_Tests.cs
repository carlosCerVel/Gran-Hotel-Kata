using System.Threading.Tasks;
using GranHotelKata.Models.TokenAuth;
using GranHotelKata.Web.Controllers;
using Shouldly;
using Xunit;

namespace GranHotelKata.Web.Tests.Controllers
{
    public class HomeController_Tests: GranHotelKataWebTestBase
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