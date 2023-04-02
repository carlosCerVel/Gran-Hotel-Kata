using System.Threading.Tasks;
using Abp.Application.Services;
using GranHotelKata.Authorization.Accounts.Dto;

namespace GranHotelKata.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
