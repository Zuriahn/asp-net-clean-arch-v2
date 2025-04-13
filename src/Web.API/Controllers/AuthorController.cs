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
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuthorsQuery());

            return result.Match(
                authors => Ok(authors),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                authorId => Ok(authorId),
                errors => Problem(errors)
            );
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                authorId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommand(id));

            return result.Match(
                authorId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}