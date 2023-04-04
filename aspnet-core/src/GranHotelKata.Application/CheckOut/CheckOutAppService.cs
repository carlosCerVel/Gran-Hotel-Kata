using Abp.Authorization;
using Abp.Domain.Repositories;
using GranHotelKata.CheckIn.Dto;
using GranHotelKata.CheckOut.Dto;
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
    public class CheckOutAppService : GranHotelKataAppServiceBase, ICheckOutAppService
    {
        private readonly IRepository<Room, long> _roomRepository;
        private readonly IRepository<Guest, long> _guestRepository;

        public CheckOutAppService(
            IRepository<Room, long> roomRepository,
            IRepository<Guest, long> guestRepository)
        {
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
        }
        public async Task<HttpStatusCode> GuestCheckOut(GuestCheckOutRequest request)
        {
            Room roomToUpdate = await _roomRepository.GetAll().Include(x => x.GuestAssigned).FirstOrDefaultAsync(x => x.Id == request.RoomSelected);

            Guest assignedGuest = roomToUpdate.GuestAssigned;

            roomToUpdate.GuestAssignedId = null;

            await _roomRepository.UpdateAsync(roomToUpdate);

            await _guestRepository.DeleteAsync(assignedGuest);

            return HttpStatusCode.OK;
        }

        public async Task<List<RoomListItemDto>> GetRoomsCurrentlyOccupied()
        {
            List<Room> roomsAvailable = await _roomRepository.GetAll().Include(x => x.GuestAssigned).Where(x => x.GuestAssigned != null).ToListAsync();
            return ObjectMapper.Map<List<RoomListItemDto>>(roomsAvailable);
        }
    }
}
