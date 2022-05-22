using System.Linq;
using AutoMapper;
using Cynet.Common.Paging;
using Cynet.Domain.Employees;
using Cynet.Domain.Insulations;
using Cynet.Domain.Quarantines;
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
        CreateTimesClockMaps();
        CreateQuarantinsMaps();
    }

    private void CreateQuarantinsMaps()
    {
        CreateMap<Quarantine, QuarantineResponse>();
    }

    private void CreateTimesClockMaps()
    {
        CreateMap<TimeClockRequest, TimeClock>();
        CreateMap<TimeClock, TimeClockResponse>();
        CreateMap<UpdateTimeClockRequest, TimeClock>();
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