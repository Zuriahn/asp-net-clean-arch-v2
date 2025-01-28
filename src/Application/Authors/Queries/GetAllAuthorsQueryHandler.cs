using Domain.Repository;
using Application.Authors.Dto;
using Domain.Entities;

namespace Application.Authors.Queries
{
    internal sealed class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, ErrorOr<IReadOnlyList<AuthorDto>>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<AuthorDto>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Author> authors = await _authorRepository.GetAllAsync();

            return authors.Select(author => new AuthorDto
            (
                author.Id.Value,
                author.Name,
                author.PhoneNumber.Value,
                new AddressDto
                (
                    author.Address.Country,
                    author.Address.State,
                    author.Address.Street,
                    author.Address.Number,
                    author.Address.Zipcode
                )
            )).ToList();
        }
    }
}