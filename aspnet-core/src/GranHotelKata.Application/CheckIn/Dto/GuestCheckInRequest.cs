using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranHotelKata.CheckIn.Dto
{
    /*
    * Guess check-in process request
    */
    public class GuestCheckInRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GuessID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public long RoomNumber { get; set; }
    }
}
