namespace CareerCompass.Api.Controllers
{
    using CareerCompass.Services.Abstractions.Repositories;
    using CareerCompass.Services.Models.Principal;
    using CareerCompass.Services.Models.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var principal = new ClaimsPrincipalWrapper(User);

            var user = await userRepository.GetById(principal.Id);

            if (user is null)
            {
                return NotFound();
            }

            var model = user.ToModel();

            return Ok(model);
        }
    }

}
