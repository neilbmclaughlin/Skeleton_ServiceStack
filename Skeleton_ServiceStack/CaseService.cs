namespace Skeleton_ServiceStack
{
	using ServiceStack.FluentValidation;
	using ServiceStack.ServiceInterface;
	using ServiceStack.ServiceInterface.Validation;

	public class CaseService : Service
    {
		private readonly ICaseRepository caseRepository;

		public CaseService(ICaseRepository caseRepository)
		{
			this.caseRepository = caseRepository;
		}

		public enum Status
        {
            Open,
            PendingClientAction,
            PendingFeeEarnerAction,
            Closed
        }

		public IValidator<Case> Validator { get; set; }

        public object Get(Case request)
        {
	        var result = this.Validator.Validate(request);

	        if (!result.IsValid)
	        {
		        throw result.ToException();
	        }
			return caseRepository.GetCaseByReference(request.Reference);
		}
    }
}
