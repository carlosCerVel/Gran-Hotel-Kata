using GranHotelKata.CheckOut.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GranHotelKata.CheckIn
{
    public interface ICheckOutAppService
    {
        Task<HttpStatusCode> GuessCheckOut(GuessCheckOutRequest request);
    }
}
