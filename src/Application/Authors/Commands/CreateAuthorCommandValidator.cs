namespace Application.Authors.Commands
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(r => r.name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.phoneNumber)
                 .NotEmpty()
                 .MaximumLength(13)
                 .WithName("Phone Number");

            RuleFor(r => r.country)
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(r => r.state)
                .NotEmpty()
                .MaximumLength(20)
                .WithName("State");

            RuleFor(r => r.street)
                .MaximumLength(20)
                .WithName("Street");

            RuleFor(r => r.number)
                .NotNull();

            RuleFor(r => r.zipcode)
                .NotEmpty()
                .MaximumLength(10)
                .WithName("Zipcode");
        }
    }
}