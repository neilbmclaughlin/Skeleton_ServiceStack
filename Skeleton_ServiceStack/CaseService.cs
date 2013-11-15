using System.Collections.Generic;

namespace Skeleton_ServiceStack
{
    using ServiceStack.ServiceInterface;
    public class CaseService : Service
    {
        public enum Status
        {
            Open,
            PendingClientAction,
            PendingFeeEarnerAction,
            Closed
        }

        private readonly Dictionary<string, CaseResponse> _caseList = new Dictionary<string, CaseResponse>
        {
            { "123456K", new CaseResponse { Reference = "123456K", ClientName = "Joe Blogs", Status = Status.PendingClientAction } },
        };

        public object Any(Case request)
        {
            return _caseList[request.Reference];
        }
    }
}
