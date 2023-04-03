using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GranHotelKata.CheckIn
{
    [AbpAuthorize]
    public class CheckInAppService : GranHotelKataAppServiceBase, ICheckInAppService
    {
        public async Task Test()
        {
        }       
    }
}
