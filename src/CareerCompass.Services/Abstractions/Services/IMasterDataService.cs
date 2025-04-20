using CareerCompass.Services.Abstractions.Models;
using CareerCompass.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCompass.Services.Abstractions.Services
{
    public interface IMasterDataService
    {
        public Task UpdateMasterData(MasterData model, IRolePrincipal principal, CancellationToken token = default);
    }
}
