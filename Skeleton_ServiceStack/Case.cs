using ServiceStack.ServiceInterface;

namespace Skeleton_ServiceStack
{
    using ServiceStack.ServiceHost;

    [Route("/case/{Reference}")]
    [Authenticate]
    public class Case
    {
        public string Reference { get; set; }
    }

}