﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GranHotelKata.Authorization.Roles;
using GranHotelKata.Authorization.Users;
using GranHotelKata.MultiTenancy;

namespace GranHotelKata.EntityFrameworkCore
{
    public class GranHotelKataDbContext : AbpZeroDbContext<Tenant, Role, User, GranHotelKataDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public GranHotelKataDbContext(DbContextOptions<GranHotelKataDbContext> options)
            : base(options)
        {
        }
    }
}
