namespace Skeleton_ServiceStack
{
	using ServiceStack.FluentValidation;

	public class CaseValidator : AbstractValidator<Case>
	{
		public IReferenceValidator ReferenceValidator { get; set; }

		public CaseValidator()
		{
			RuleFor(r => r.Reference).Must(x => ReferenceValidator.CaseExists(x)).WithErrorCode("NoCaseWithMatchingReference");
		}
	}
}