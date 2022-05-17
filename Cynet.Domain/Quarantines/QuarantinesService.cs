using Cynet.Common.Paging;

namespace Cynet.Domain.Quarantines
{
    internal class QuarantinesService :IQuarantinesService
    {
        public Task<List<Guid>> AddQuarantineRangeAsync(List<QuarantineRequest> quarantines)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> AddQuarantineAsync(QuarantineRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Page<QuarantineResponse>> GetQuarantinesAsync(QuarantineQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
