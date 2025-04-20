using CareerCompass.DataContext.Enums;
using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Enums;
using CareerCompass.Services.Extensions;
using CareerCompass.Services.Models.MasterData;
using CareerCompass.Services.Models.Principal;
using CareerCompass.Services.Models.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerCompass.Api.Controllers
{
    [Authorize]
    [Route("api/v1/masterdata")]
    [ApiController]
    [Route("api/v1/master-data")]
    public class MasterDataController : ControllerBase
    {
        private readonly IValidator<MasterData> masterDataValidator;
        private readonly IMasterDataService masterDataService;

        public MasterDataController(IMasterDataService masterDataService)
        {
            this.masterDataValidator = masterDataValidator;
            this.masterDataService = masterDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMasterData(CancellationToken token = default)
        {
            var principal = new ClaimsPrincipalWrapper(User);

            var model = await masterDataService.GetMasterData(principal, token);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet, Route("skills-options")]
        public IActionResult GetSkillsOptions()
        {
            var options = Enum.GetValues<Skills>().Where(x => x != Skills.None).Select(x => new OptionsModel(x.GetDescription() ?? string.Empty, (int)x, x.ToString()));
            return Ok(options);
        }

        [HttpGet, Route("areas-of-interest-options")]
        public IActionResult GetAreasOfInterestOptions()
        {
            var options = Enum.GetValues<AreaOfInterest>().Where(x => x != AreaOfInterest.None).Select(x => new OptionsModel(x.GetDescription() ?? string.Empty, (int)x, x.ToString()));
            return Ok(options);
        }

        [HttpGet, Route("subject-options")]
        public IActionResult GetSubjectOptions()
        {
            var options = Enum.GetValues<SubjectType>().Where(x => x != SubjectType.None).Select(x => new OptionsModel(x.GetDescription() ?? string.Empty, (int)x, x.ToString()));
            return Ok(options);
        }

        [HttpGet, Route("career-goal-options")]
        public IActionResult GetCareerGoalOptions()
        {
            var options = Enum.GetValues<CareerGoal>().Where(x => x != CareerGoal.None).Select(x => new OptionsModel(x.GetDescription() ?? string.Empty, (int)x, x.ToString()));
            return Ok(options);
        }
    }
}
