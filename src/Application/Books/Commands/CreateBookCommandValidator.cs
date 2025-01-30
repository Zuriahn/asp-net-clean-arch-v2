namespace Application.Books.Commands
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(r => r.title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.description)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(r => r.pages)
                .NotNull();

            RuleFor(r => r.authorId)
                .NotNull();

        }
    }
}