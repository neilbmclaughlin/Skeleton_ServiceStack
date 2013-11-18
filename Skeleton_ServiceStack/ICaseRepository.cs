namespace Skeleton_ServiceStack
{
	using System.Collections.Generic;

	public interface ICaseRepository
	{
		bool CaseExists(string caseReference);
		IList<Case> GetCasesByReference(string caseReference);
	}
}