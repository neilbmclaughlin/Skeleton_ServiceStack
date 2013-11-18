namespace Skeleton_ServiceStack
{
	using System.Collections.Generic;
	using System.Linq;

	public class InMemoryCaseRepository : ICaseRepository
	{
		private readonly Dictionary<string, Case> _caseList = new Dictionary<string, Case>
																		{
																			{ "123456K", new Case { Reference = "123456K", ClientName = "Joe Bloggs", Status = Status.PendingClientAction } },
																			{ "456789K", new Case { Reference = "456789K", ClientName = "Fred Smith", Status = Status.Closed } },
																		};


		public bool CaseExists(string caseReference)
		{
			return _caseList.ContainsKey(caseReference);
		}

		public IList<Case> GetCasesByReference(string caseReference)
		{
			return string.IsNullOrEmpty(caseReference) 
				? _caseList.Values.ToList() 
				: new List<Case>() { _caseList[caseReference] };
		}
	}
}