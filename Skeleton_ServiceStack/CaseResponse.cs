namespace Skeleton_ServiceStack
{
    public class CaseResponse
    {
        public string Reference { get; set; }
        public string ClientName  { get; set; }
        public CaseService.Status Status  { get; set; }
    }
}