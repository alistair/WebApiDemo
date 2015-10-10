using FluentValidation;

namespace WebApplicationPoC.Models
{
	public class AddressValidator : AbstractValidator<Address>
	{
		public AddressValidator()
		{
			RuleFor(_ => _.Street).NotEmpty();
			RuleFor(_ => _.City).NotEmpty();
			RuleFor(_ => _.Country).NotEmpty();
		}
	}
}