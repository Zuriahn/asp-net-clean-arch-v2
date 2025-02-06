using Application.Authors.Queries;
using Application.Authors.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Web.API.Controllers
{
    [Route("Authors")]
    [Authorize]
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
            var result = await _mediator.Send(new GetAllAuthorsQuery());

            return result.Match(
                authors => Ok(authors),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                authorId => Ok(authorId),
                errors => Problem(errors)
            );
        }
    }
}