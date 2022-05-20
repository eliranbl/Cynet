using Cynet.Domain.Employees;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cynet.Domain.TimeClocks;

namespace Cynet.Tests;

[TestFixture]
public class TimeClocksControllerTests : ControllerTestsBase
{
    private const string _timeClocksBaseURL = "/v1/TimesClock";
    private const string _employeesBaseURL = "/v1/Employees";


    [Test]
    public async Task CanInsertEnterToTimeClock()
    {
        var createEmployeeRequest = new CreateEmployeeRequest
        {
            Email = $"{Guid.NewGuid()}@test.com",
            FirstName = "First name Test",
            LastName = "Last name test"
        };

        await HttpClient.PostAsJsonAsync(_employeesBaseURL, createEmployeeRequest);

        var request = new TimeClockRequest
        {
            Value = DateTime.UtcNow,
            EmployeeEmail = createEmployeeRequest.Email,
            TimeClockType = TimeClockType.Enter
        };

        var response = await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, request);
        var responseContentString = await response.Content.ReadAsStringAsync();

        var viewModel = JsonConvert.DeserializeObject<TimeClockResponse>(responseContentString);

        viewModel.Employee.Email.Equals(createEmployeeRequest.Email);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task CreateNewEmployee()
    {
        var request = new CreateEmployeeRequest
        {
            Email = $"{Guid.NewGuid()}@test.com",
            FirstName = "First name Test",
            LastName = "Last name test"
        };

        var response = await HttpClient.PostAsJsonAsync(_employeesBaseURL, request);
        var responseContentString = await response.Content.ReadAsStringAsync();

        var viewModel = JsonConvert.DeserializeObject<Guid>(responseContentString);

        viewModel.Should().NotBeEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}