using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Models.User;

namespace CareerCompass.Services.Abstractions.Services
{
    public interface IMasterDataService
    {
        Task<MasterData?> GetMasterData(IRolePrincipal principal, CancellationToken token = default);
    }
}
