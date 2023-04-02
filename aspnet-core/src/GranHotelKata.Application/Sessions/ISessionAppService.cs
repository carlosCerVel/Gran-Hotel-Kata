using System.Threading.Tasks;
using Abp.Application.Services;
using GranHotelKata.Sessions.Dto;

namespace GranHotelKata.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
