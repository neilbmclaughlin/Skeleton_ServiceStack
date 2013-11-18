namespace Skeleton_ServiceStack
{
	using System.Collections.Generic;

	using ServiceStack.ServiceHost;
	using ServiceStack.ServiceInterface;

	[Route("/cases")]
	[Route("/cases/{Reference}")]
	//[Authenticate]
	public class Cases
	{
		public string Reference { get; set; }
	}

	public class CasesResponse
	{
		public string Reference { get; set; }
		public IList<Case> Cases { get; set; }
	}

	[ClientCanSwapTemplates]
	[DefaultView("Cases")]
	public class CasesService : Service
    {
		private readonly ICaseRepository caseRepository;

		public CasesService(ICaseRepository caseRepository)
		{
			this.caseRepository = caseRepository;
		}

        public object Get(Cases request)
        {
	        return new CasesResponse
						{
							Reference = request.Reference,
							Cases = caseRepository.GetCasesByReference(request.Reference)
						};
        }
    }
}
