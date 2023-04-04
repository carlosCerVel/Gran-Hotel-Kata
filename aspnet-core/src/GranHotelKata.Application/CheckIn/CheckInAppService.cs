using Abp.Authorization;
using GranHotelKata.CheckIn.Dto;
using GranHotelKata.Main;
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
    public class CheckInAppService : GranHotelKataAppServiceBase, ICheckInAppService
    {
        /// <summary>
        /// Process to add a new guess to the hotel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> NewGuessCheckIn(GuestCheckInRequest request)
        {
            Guess newGuess = ObjectMapper.Map<Guess>(request);

            newGuess.CheckInDate = newGuess.CheckInDate.ToUniversalTime();
            newGuess.CheckOutDate = newGuess.CheckOutDate.ToUniversalTime();

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Process to get all available rooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<Room>> GetAvailableRooms()
        {
            return new List<Room>();
        }
    }
}
