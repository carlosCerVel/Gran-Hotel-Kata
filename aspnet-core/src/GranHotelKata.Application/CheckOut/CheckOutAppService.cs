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
        private readonly IRepository<Guess, long> _guessRepository;

        public CheckOutAppService(
            IRepository<Room, long> roomRepository,
            IRepository<Guess, long> guessRepository)
        {
            _roomRepository = roomRepository;
            _guessRepository = guessRepository;
        }
        public async Task<HttpStatusCode> GuessCheckOut(GuessCheckOutRequest request)
        {
            Room roomToUpdate = await _roomRepository.GetAll().Include(x => x.GuessAssigned).FirstOrDefaultAsync(x => x.Id == request.RoomSelected);

            Guess assignedGuess = roomToUpdate.GuessAssigned;

            roomToUpdate.GuessAssignedId = null;

            await _roomRepository.UpdateAsync(roomToUpdate);

            await _guessRepository.DeleteAsync(assignedGuess);

            return HttpStatusCode.OK;
        }

        public async Task<List<RoomListItemDto>> GetRoomsCurrentlyOccupied()
        {
            List<Room> roomsAvailable = await _roomRepository.GetAll().Include(x => x.GuessAssigned).Where(x => x.GuessAssigned != null).ToListAsync();
            return ObjectMapper.Map<List<RoomListItemDto>>(roomsAvailable);
        }
    }
}
