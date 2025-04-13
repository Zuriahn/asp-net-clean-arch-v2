namespace Application.Authors.Commands
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(r => r.id)
                .NotEmpty();
        }
    }
}