using Abp.Application.Services.Dto;

namespace GranHotelKata.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

