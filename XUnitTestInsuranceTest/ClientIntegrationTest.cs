using InsuranceTest.API.DTO.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestInsuranceTest
{
    public class ClientIntegrationTest
    {
        [Fact]
        public async Task GetAll_HttpAccess_returnData()
        {
             var client = new integrationClassProvider().Client;

            UserLoginDTO login = new UserLoginDTO();
            login.username = "Josue";
            login.password = "Admin123";

            string json = JsonConvert.SerializeObject(login);

            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/User/login", content);

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

    }
}
