namespace CareerCompass.Api.Controllers
{
    using System;
    using CareerCompass.Services.Abstractions.Services;
    using CareerCompass.Services.Constants;
    using CareerCompass.Services.Models.Auth;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IJwtService jwtService;
        private readonly IUserService userService;
        private readonly IValidator<Login> loginValidator;
        private readonly IValidator<Register> registerValidator;

        public AuthController(
            IAuthService authService,
            IJwtService jwtService,
            IUserService userService,
            IValidator<Login> loginValidator,
            IValidator<Register> registerValidator)
        {
            this.authService = authService;
            this.jwtService = jwtService;
            this.userService = userService;
            this.loginValidator = loginValidator;
            this.registerValidator = registerValidator;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] Login model)
        {
            if (!loginValidator.Validate(model).IsValid)
            {
                return BadRequest();
            }

            var user = await authService.AuthenticateWithEmailAndPassword(model.Email, model.Password);

            if (user is null)
            {
                return NotFound();
            }

            var (jwtToken, expiryInMinutes) = jwtService.CreateToken(user);

            AddJwtCookie(jwtToken, expiryInMinutes);

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (!registerValidator.Validate(model).IsValid)
            {
                return BadRequest();
            }

            var user = await userService.Register(model);

            var (jwtToken, expiryInMinutes) = jwtService.CreateToken(user);

            if (jwtToken is null)
            {
                throw new Exception("An error occurred while trying to create jwt token.");
            }

            AddJwtCookie(jwtToken, expiryInMinutes);

            return Ok();
        }

        [HttpPost("signout")]
        public IActionResult SignOut()
        {
            ClearJwtCookie();
            return Ok();
        }

        private void AddJwtCookie(string jwtToken, int? expiryInMinutes)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expiryInMinutes.HasValue ? DateTimeOffset.Now.AddMinutes(Convert.ToDouble(expiryInMinutes)) : null,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("jwt", jwtToken, cookieOptions);
        }

        private void ClearJwtCookie()
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(-1),
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("jwt", string.Empty, cookieOptions);
        }
    }

}
