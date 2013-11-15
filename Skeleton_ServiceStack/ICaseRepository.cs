namespace Skeleton_ServiceStack
{
	public interface ICaseRepository
	{
		bool CaseExists(string caseReference);
		CaseResponse GetCaseByReference(string caseReference);
	}
}