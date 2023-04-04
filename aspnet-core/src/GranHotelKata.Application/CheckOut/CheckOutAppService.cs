using Abp.Authorization;
using GranHotelKata.CheckOut.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GranHotelKata.CheckIn
{
     /*
     * Class that contains methods related to the check-in process
     */
    [AbpAuthorize]
    public class CheckOutAppService : GranHotelKataAppServiceBase, ICheckOutAppService
    {
        public async Task<HttpStatusCode> GuessCheckOut(GuessCheckOutRequest request)
        {
            return HttpStatusCode.OK;
        }       
    }
}
