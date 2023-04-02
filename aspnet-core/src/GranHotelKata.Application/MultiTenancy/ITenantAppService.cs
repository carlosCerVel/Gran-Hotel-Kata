using Abp.Application.Services;
using GranHotelKata.MultiTenancy.Dto;

namespace GranHotelKata.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

