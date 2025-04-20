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
    public class MasterDataService : IMasterDataService
    {
        private readonly IUserRepository userRepository;
        private readonly IRolePrincipal rolePrincipal;
        private readonly IValidator<MasterData> masterDataValidator;

        public async Task UpdateMasterData(MasterData model, IRolePrincipal principal, CancellationToken token = default)
        {
            if (principal.IsInRole("Admin")) //?
            {
                throw new UnauthorizedAccessException("You do not have permission to update master data.");
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "MasterData model cannot be null.");
            }
            var validationResult = await masterDataValidator.ValidateAsync(model, token);

            if (!validationResult.IsValid)
            {

                try
                {
                    //missing repository
                    // Assuming we are updating data in a repository/database
                    //await _dataRepository.UpdateMasterDataAsync(model, token);
                }
                catch (OperationCanceledException)
                {
                    // Handle task cancellation if needed
                    throw new TaskCanceledException("Update operation was canceled.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., database connection issues, etc.)
                    throw new Exception("An error occurred while updating master data.", ex);
                }
            }
        }
    }  
}
