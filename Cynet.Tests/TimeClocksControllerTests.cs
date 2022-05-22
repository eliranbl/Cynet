using Cynet.Common.Paging;
using Cynet.Domain.Employees;
using Cynet.Domain.TimeClocks;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cynet.Tests;

[TestFixture]
public class TimeClocksControllerTests : ControllerTestsBase
{

    [Test]
    public async Task CanEnterToOfficeTimeClockAsync()
    {
        var email = await CreateEmployee();

        var request = TimeClockRequest(email, TimeClockType.Enter, DateTime.UtcNow);

        var response = await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, request);

        var viewModel = await DeserializeObject<TimeClockResponse>(response);

        viewModel.Employee.Email.Equals(email);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }

    [Test]
    public async Task CanLeaveOfficeTimeClockAsync()
    {
        var email = await CreateEmployee();

        var requestEnter = TimeClockRequest(email, TimeClockType.Enter, DateTime.UtcNow);
        await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, requestEnter);

        var requestLeave = TimeClockRequest(email, TimeClockType.Leave, DateTime.UtcNow.AddHours(1));

        var response = await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, requestLeave);

        var viewModel = await DeserializeObject<TimeClockResponse>(response);

        viewModel.Employee.Email.Equals(email);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task CanUpdateTimeClockAsync()
    {
        var email = await CreateEmployee();

        var timeClockRequest = TimeClockRequest(email, TimeClockType.Enter, DateTime.UtcNow);
        var enterResponse = await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, timeClockRequest);

        var viewModel = await DeserializeObject<TimeClockResponse>(enterResponse);

        var updateRequest = new UpdateTimeClockRequest
        {
            EnterTime = "12:05",
            LeaveTime = "13:04",
        };

        var response = await HttpClient.PutAsJsonAsync($"{_timeClocksBaseURL}/{viewModel.Id}/UpdateAsync", updateRequest);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task CanGetQueryAsync()
    {
        var email = await CreateEmployee();
        var timeClockRequest = TimeClockRequest(email, TimeClockType.Enter, DateTime.UtcNow);
        await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, timeClockRequest);

        var query = new TimeClockQuery
        {
            Email = email,
            PageNo = 1,
            PageSize = 10
        };
        var url =
            $"{_timeClocksBaseURL}" +
            $"?Email={email}" +
            $"&PageNo={query.PageNo}" +
            $"&PageSize={query.PageSize}";

        var queryResponse = await HttpClient.GetAsync(url);

        var viewModel = await DeserializeObject<Page<TimeClockResponse>>(queryResponse);

        viewModel.Items.Should().NotBeNullOrEmpty();
        viewModel.PageSize.Should().Be(query.PageSize);
    }

    private async Task<string> CreateEmployee()
    {
        var employeeRequest = new CreateEmployeeRequest
        {
            Email = $"{Guid.NewGuid()}@test.com",
            FirstName = "First name Test",
            LastName = "Last name test"
        };

        var response = await HttpClient.PostAsJsonAsync(_employeesBaseURL, employeeRequest);

        var viewModel = await DeserializeObject<Guid>(response);

        viewModel.Should().NotBeEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        return employeeRequest.Email;
    }

    private TimeClockRequest TimeClockRequest(string email, TimeClockType type, DateTime date)
    {
        return new TimeClockRequest
        {
            Value = date,
            Email = email,
            TimeClockType = type
        };
    }
}