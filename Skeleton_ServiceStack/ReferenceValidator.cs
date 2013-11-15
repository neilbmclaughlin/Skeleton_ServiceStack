namespace Skeleton_ServiceStack
{
	public class ReferenceValidator : IReferenceValidator
	{
		private readonly ICaseRepository service;

		public ReferenceValidator(ICaseRepository service)
		{
			this.service = service;
		}

		public bool CaseExists(string caseReference)
		{
			return service.CaseExists(caseReference);
		}
	}
}