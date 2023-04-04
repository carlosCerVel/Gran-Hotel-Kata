using AutoMapper;
using GranHotelKata.CheckIn.Dto;
using GranHotelKata.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace GranHotelKata
{
    /*
    * Class that contains definitions for custom mappings
    */
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Guess, GuestCheckInRequest>().ReverseMap();

            configuration.CreateMap<Room, RoomListItemDto>().ReverseMap();

        }
    }
}
