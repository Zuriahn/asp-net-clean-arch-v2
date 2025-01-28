namespace Application.Authors.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(r => r.name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.phoneNumber)
                 .NotEmpty()
                 .MaximumLength(13)
                 .WithName("Phone Number");

            RuleFor(r => r.address.country)
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(r => r.address.state)
                .NotEmpty()
                .MaximumLength(20)
                .WithName("State");

            RuleFor(r => r.address.street)
                .MaximumLength(20)
                .WithName("Street");

            RuleFor(r => r.address.number)
                .NotNull();

            RuleFor(r => r.address.zipcode)
                .NotEmpty()
                .MaximumLength(10)
                .WithName("Zip Code");
        }
    }
}