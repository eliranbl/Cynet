using Cynet.Domain.Employees;
using Cynet.Domain.Quarantines;
using Cynet.Domain.TimeClocks;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cynet.Tests;

[TestFixture]
public class QuarantinesControllerTests : ControllerTestsBase
{
    [Test]
    public async Task DeclarePositiveAsync()
    {
        string email = null;

        for (var i = 0; i < 4; i++)
        {
            email = await CreateDataForTest();
        }

        var quarantineRequest = new QuarantineRequest
        {
            Email = email,
            FromDate = DateTime.Parse(DateTime.UtcNow.ToShortDateString())
        };

        var response = await HttpClient.PostAsJsonAsync(_quarantinesBaseURL, quarantineRequest);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    private async Task<string> CreateDataForTest()
    {
        var email = await CreateEmployee();
        await CanEnterToOfficeTimeClockAsync(email);
        return email;
    }

    private async Task<TimeClockResponse> CanEnterToOfficeTimeClockAsync(string email)
    {
        var request = CreateTimeClockRequest(email, TimeClockType.Enter, DateTime.UtcNow);

        var response = await HttpClient.PostAsJsonAsync(_timeClocksBaseURL, request);

        var viewModel = await DeserializeObject<TimeClockResponse>(response);

        viewModel.Employee.Email.Equals(email);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        return viewModel;
    }

    private TimeClockRequest CreateTimeClockRequest(string email, TimeClockType type, DateTime date)
    {
        return new TimeClockRequest
        {
            Value = date,
            Email = email,
            TimeClockType = type
        };
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
}