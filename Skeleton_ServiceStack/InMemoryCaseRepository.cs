namespace Skeleton_ServiceStack
{
	using System.Collections.Generic;

	public class InMemoryCaseRepository : ICaseRepository
	{
		private readonly Dictionary<string, CaseResponse> _caseList = new Dictionary<string, CaseResponse>
																		{
																			{ "123456K", new CaseResponse { Reference = "123456K", ClientName = "Joe Bloggs", Status = CaseService.Status.PendingClientAction } },
																			{ "456789K", new CaseResponse { Reference = "456789K", ClientName = "Fred Smith", Status = CaseService.Status.Closed } },
																		};


		public bool CaseExists(string caseReference)
		{
			return _caseList.ContainsKey(caseReference);
		}

		public CaseResponse GetCaseByReference(string caseReference)
		{
			return _caseList[caseReference];
		}
	}
}