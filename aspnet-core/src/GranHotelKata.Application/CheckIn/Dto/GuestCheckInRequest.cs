using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranHotelKata.CheckIn.Dto
{
    /*
    * Guest check-in process request
    */
    public class GuestCheckInRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GuestID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public long RoomSelected { get; set; }
    }
}
