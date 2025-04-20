using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Models.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerCompass.Api.Controllers
{
    [Authorize]
    [Route("api/v1/masterdata")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IValidator<MasterData> masterDataValidator;
        private readonly IMasterDataService masterDataService;

        public MasterDataController(
            IValidator<MasterData> masterDataValidator,
            IMasterDataService masterDataService)
        {
            this.masterDataValidator = masterDataValidator;
            this.masterDataService = masterDataService;
        }

        //missing repository, when the method in the service is done, call it from there.
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] MasterData model, CancellationToken cancellationToken)
        {
            var validationResult = await masterDataValidator.ValidateAsync(model, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }
    }
}
