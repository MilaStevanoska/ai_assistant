using CareerCompass.DataContext;
using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Abstractions.Repositories;
using CareerCompass.Services.Abstractions.Services;
using CareerCompass.Services.Models.User;

namespace CareerCompass.Services.Services
{
    public class MasterDataService
        : BaseService, IMasterDataService
    {
        private readonly IUserRepository userRepository;

        public MasterDataService(
            DatabaseContext dbContext,
            IUserRepository userRepository)
            : base(dbContext)
        {
            this.userRepository = userRepository;
        }

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
