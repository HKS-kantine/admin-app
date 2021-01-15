using AdminApp.Controllers;
using AdminLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    public class AuthContollerTest
    {
        private readonly AuthController _auth = new AuthController();
        private LoginEntity _login;

        [SetUp]
        public void Setup()
        {
            _login = new LoginEntity()
            {
                Username = "maarten.jakobs@gmail.com",
                Password = "sonu@123"
            };
        }

        [Test]
        public void AA_AC_01__auth_wrong_username()
        {
            _login.Username = null;
            if (_auth.Authenticate(_login) is OkObjectResult)
            {
                Assert.Fail("was authenticated");
            }
            Assert.Pass();
        }

        [Test]
        public void AA_AC_02__auth_wrong_password()
        {
            _login.Password = null;
            if (_auth.Authenticate(_login) is OkObjectResult)
            {
                Assert.Fail("was authenticated");
            }
            Assert.Pass();
        }

        [Test]
        public void AA_AC_03__auth_loggedin()
        {
            if (_auth.Authenticate(_login) is OkObjectResult)
            {
                Assert.Pass();
            }
            Assert.Fail("was not authenticated");
        }
    }
}