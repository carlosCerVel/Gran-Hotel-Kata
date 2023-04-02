using System.Threading.Tasks;
using GranHotelKata.Configuration.Dto;

namespace GranHotelKata.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
