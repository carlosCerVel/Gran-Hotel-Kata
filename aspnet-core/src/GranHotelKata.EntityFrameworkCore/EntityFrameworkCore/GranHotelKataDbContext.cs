using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GranHotelKata.Authorization.Roles;
using GranHotelKata.Authorization.Users;
using GranHotelKata.MultiTenancy;
using GranHotelKata.Main;

namespace GranHotelKata.EntityFrameworkCore
{
    public class GranHotelKataDbContext : AbpZeroDbContext<Tenant, Role, User, GranHotelKataDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public GranHotelKataDbContext(DbContextOptions<GranHotelKataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guests { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

    }
}
