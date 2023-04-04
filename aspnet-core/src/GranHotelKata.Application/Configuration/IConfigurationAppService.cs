using System.Threading.Tasks;
using GranHotelKata.Configuration.Dto;

namespace GranHotelKata.Configuration
{
    /*
     * Interface used to contain methods related to the check-in process
     */
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
