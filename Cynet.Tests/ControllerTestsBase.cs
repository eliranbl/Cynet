using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cynet.Tests;

[TestFixture]
public abstract class ControllerTestsBase
{
    protected HttpClient HttpClient;

    private const string version = "/v1";
    protected const string _employeesBaseURL = $"{version}/Employees";
    protected const string _timeClocksBaseURL = $"{version}/TimesClock";
    protected const string _quarantinesBaseURL = $"{version}/Quarantines";

    [SetUp]
    public virtual async Task SetUpAsync()
    {
        HttpClient = Config.HttpClient;
        await ClearDataAsync();
    }

    [TearDown]
    public virtual async Task TearDownAsync()
    {
        await ClearDataAsync();
    }

    private Task ClearDataAsync()
    {
        return Task.CompletedTask;
    }

    protected static async Task<T> DeserializeObject<T>(HttpResponseMessage httpResponse)
    {
        var responseContentString = await httpResponse.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(responseContentString);
    }
}