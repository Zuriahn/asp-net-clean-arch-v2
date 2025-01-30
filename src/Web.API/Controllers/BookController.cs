using Application.Books.Queries;
using Application.Books.Commands;

namespace Web.API.Controllers
{
    [Route("Books")]
    public class Books : ApiController
    {
        private readonly ISender _mediator;

        public Books(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());

            return result.Match(
                books => Ok(books),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                bookId => Ok(bookId),
                errors => Problem(errors)
            );
        }
    }
}