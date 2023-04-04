using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GranHotelKata.CheckIn.Dto;
using GranHotelKata.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<Room, long> _roomRepository;
        private readonly IRepository<Guest, long> _guestRepository;

        public CheckInAppService(
            IRepository<Room, long> roomRepository,
            IRepository<Guest, long> guestRepository)
        {
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
        }
        /// <summary>
        /// Process to add a new guest to the hotel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> NewGuestCheckIn(GuestCheckInRequest request)
        {
            Guest preExistingGuest = await _guestRepository.FirstOrDefaultAsync(x => x.GuestID.ToLower() == request.GuestID.ToLower());
            if (preExistingGuest != null)
            {
                throw new UserFriendlyException("User is already present on the system");
            }

            Guest newGuest = ObjectMapper.Map<Guest>(request);

            newGuest.CheckInDate = newGuest.CheckInDate.ToUniversalTime();
            newGuest.CheckOutDate = newGuest.CheckOutDate.ToUniversalTime();

            long newGuestId = await _guestRepository.InsertAndGetIdAsync(newGuest);

            Room roomToUpdate = await _roomRepository.GetAsync(request.RoomSelected);

            roomToUpdate.GuestAssignedId = newGuestId;

            await _roomRepository.UpdateAsync(roomToUpdate);

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Process to get all available rooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoomListItemDto>> GetAvailableRooms()
        {
            List<Room> roomsAvailable = await _roomRepository.GetAll().Include(x => x.GuestAssigned).Where(x => x.GuestAssigned == null).ToListAsync();
            return ObjectMapper.Map<List<RoomListItemDto>>(roomsAvailable);
        }
    }
}
