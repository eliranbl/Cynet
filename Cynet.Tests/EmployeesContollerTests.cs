using Cynet.Domain.Employees;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cynet.Tests;

[TestFixture]
public class EmployeesControllerTests : ControllerTestsBase
{
    [Test]
    public async Task CreateEmployee()
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
    }
}