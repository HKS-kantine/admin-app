using AdminEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminAuth
{
    public class AuthController : IAuth
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://431901-authentication-service.azurewebsites.net/")
        };

        public async Task<AuthDto> Login(string User, string Password)
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json")
            //);
            HttpResponseMessage response = await client.PostAsync("/api/user", new StringContent(JsonConvert.SerializeObject(new { Username = User, Password }),
                Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            AuthDto accessToken = JsonConvert.DeserializeObject<AuthDto>(result);

            if (accessToken.auth_token == null)
            {
                return null;
            }

            return accessToken;
        }
    }
}
