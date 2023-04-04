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
        private readonly IRepository<Guess, long> _guessRepository;

        public CheckInAppService(
            IRepository<Room, long> roomRepository,
            IRepository<Guess, long> guessRepository)
        {
            _roomRepository = roomRepository;
            _guessRepository = guessRepository;
        }
        /// <summary>
        /// Process to add a new guess to the hotel
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> NewGuessCheckIn(GuestCheckInRequest request)
        {
            Guess preExistingGuess = await _guessRepository.FirstOrDefaultAsync(x => x.GuessID.ToLowerInvariant() == request.GuessID.ToLowerInvariant());
            if (preExistingGuess != null)
            {
                throw new UserFriendlyException("User is already present on the system");
            }

            Guess newGuess = ObjectMapper.Map<Guess>(request);

            newGuess.CheckInDate = newGuess.CheckInDate.ToUniversalTime();
            newGuess.CheckOutDate = newGuess.CheckOutDate.ToUniversalTime();

            long newGuessId = await _guessRepository.InsertAndGetIdAsync(newGuess);

            Room roomToUpdate = await _roomRepository.GetAsync(request.RoomSelected);

            roomToUpdate.GuessAssignedId = newGuessId;

            await _roomRepository.UpdateAsync(roomToUpdate);

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Process to get all available rooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoomListItemDto>> GetAvailableRooms()
        {
            List<Room> roomsAvailable = await _roomRepository.GetAll().Include(x => x.GuessAssigned).Where(x => x.GuessAssigned == null).ToListAsync();
            return ObjectMapper.Map<List<RoomListItemDto>>(roomsAvailable);
        }
    }
}
