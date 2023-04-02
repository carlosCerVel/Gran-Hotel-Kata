using Abp.MultiTenancy;
using GranHotelKata.Authorization.Users;

namespace GranHotelKata.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
