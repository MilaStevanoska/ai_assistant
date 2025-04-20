using CareerCompass.DataContext;
using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Models.User;
using CareerCompass.Services.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CareerCompass.Services.Services
{
    public class MasterDataService
        : BaseService, IMasterDataService
    {
        private readonly IUserRepository userRepository;
        private readonly IRolePrincipal rolePrincipal;
        private readonly IValidator<MasterData> masterDataValidator;

        public MasterDataService(
            DatabaseContext dbContext,
            IUserRepository userRepository)
            : base(dbContext)
        {
            this.userRepository = userRepository;
        }
            var validationResult = await masterDataValidator.ValidateAsync(model, token);

        public async Task<MasterData?> GetMasterData(IRolePrincipal principal, CancellationToken token = default)
        {
            var user = await userRepository.GetById(principal.Id, token);

            if (user is null)
            {
                return null;
            }

            var model = user.ToMasterData();

            return model;
        }
    }
}
