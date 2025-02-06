using Application.Users.Commands;
using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Web.API.Controllers
{
    [Route("Users")]
    [Authorize]
    public class Users : ApiController
    {
        private readonly ISender _mediator;

        public Users(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByEmailAndPassword([FromQuery] string email, [FromQuery] string password)
        {
            var result = await _mediator.Send(new GetUserByEmailAndPasswordQuery(email, password));

            return result.Match(
                session => Ok(session),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                user => Ok(user),
                errors => Problem(errors)
            );
        }
    }
}