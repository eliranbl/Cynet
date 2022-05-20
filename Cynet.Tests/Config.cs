using Cynet.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Net.Http;

namespace Cynet.Tests
{
    [SetUpFixture]
    public class Config
    {
        private static IConfiguration _configuration;

        public static CynetDbContext DBContext;
        public static HttpClient HttpClient;

        [OneTimeSetUp]
        public static void SetUpFixture()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DBContext = CreateDbContext();

            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(_configuration)
                .UseStartup<Startup>());

            HttpClient = server.CreateClient();
        }

        public static CynetDbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CynetDbContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;

            return new CynetDbContext(dbContextOptions);
        }
    }
}
