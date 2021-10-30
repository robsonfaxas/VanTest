using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;
using VanhackTest.MultiTenancy;

namespace VanhackTest.EntityFrameworkCore
{
    public class VanhackTestDbContext : AbpZeroDbContext<Tenant, Role, User, VanhackTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public VanhackTestDbContext(DbContextOptions<VanhackTestDbContext> options)
            : base(options)
        {
        }
    }
}
