using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    public class ProductControllerTest : IntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Get_all_productsAsync()
        {
            var response = await TestClient.GetAsync("/api/product");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}