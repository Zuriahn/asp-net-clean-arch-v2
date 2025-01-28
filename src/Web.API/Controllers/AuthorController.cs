using Application.Authors.Queries;
using Application.Authors.Commands;

namespace Web.API.Controllers
{
    [Route("Authors")]
    public class Authors : ApiController
    {
        private readonly ISender _mediator;

        public Authors(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorsResult = await _mediator.Send(new GetAllAuthorsQuery());

            return authorsResult.Match(
                authors => Ok(authors),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                authorId => Ok(authorId),
                errors => Problem(errors)
            );
        }
    }
}