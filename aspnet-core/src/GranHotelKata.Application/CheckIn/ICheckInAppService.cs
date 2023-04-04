using GranHotelKata.CheckIn.Dto;
using GranHotelKata.Main;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GranHotelKata.CheckIn
{
    public interface ICheckInAppService
    {
        Task<List<RoomListItemDto>> GetAvailableRooms();
        Task<HttpStatusCode> NewGuestCheckIn(GuestCheckInRequest request);
    }
}
