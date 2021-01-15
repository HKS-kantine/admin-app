using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IntegrationTests.Controllers
{
    class AuthControllerTest : IntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Login_with_correct_user_Async()
        {
            var response = await TestClient.PostAsync("/api/auth", new StringContent(JsonConvert.SerializeObject(new { Username = "maarten.jakobs@gmail.com", Password = "sonu@123" }),
                Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public async Task Login_with_wrong_password_Async()
        {
            var response = await TestClient.PostAsync("/api/auth", new StringContent(JsonConvert.SerializeObject(new { Username = "maarten.jakobs@gmail.com", Password = "fout" }),
                Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public async Task Login_with_wrong_username_Async()
        {
            var response = await TestClient.PostAsync("/api/auth", new StringContent(JsonConvert.SerializeObject(new { Username = "maarten@gmail.com", Password = "sonu@123" }),
                Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}
