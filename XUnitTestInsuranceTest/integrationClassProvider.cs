using InsuranceTest.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XUnitTestInsuranceTest
{
    public class integrationClassProvider
    {
        public HttpClient Client { get; private set; }
        public integrationClassProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

           Client= server.CreateClient();
        }
    }
}
