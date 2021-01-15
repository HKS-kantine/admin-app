using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    public class UserControllerTest : IntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_all_usersAsync()
        {
            var response = await TestClient.GetAsync("/api/user");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}