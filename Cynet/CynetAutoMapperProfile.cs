using AutoMapper;
using Cynet.Common.Paging;
using Cynet.Domain.Employees;
using Cynet.Domain.TimeClocks;

namespace Cynet;

/// <summary>
/// Cynet auto mapper profile.
/// </summary>
public class CynetAutoMapperProfile : Profile
{
    public CynetAutoMapperProfile()
    {
        CreateCommonMaps();
        CreateEmployeesMaps();
        CreateTimeClocksMaps();
    }

    private void CreateTimeClocksMaps()
    {
        CreateMap<TimeClockRequest, TimeClock>();
        CreateMap<TimeClock, TimeClockResponse>();
        CreateMap<UpdateTimeClock, TimeClock>();
    }

    private void CreateEmployeesMaps()
    {
        CreateMap<Employee, EmployeesResponse>();   
        CreateMap<CreateEmployeeRequest, Employee>();
    }

    private void CreateCommonMaps()
    {
        CreateMap(typeof(Page<>), typeof(Page<>));
    }
}