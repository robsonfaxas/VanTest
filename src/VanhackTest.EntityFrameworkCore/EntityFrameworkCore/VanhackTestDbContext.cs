using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;
using VanhackTest.MultiTenancy;
using VanhackTest.Domain;
using System.Reflection;

namespace VanhackTest.EntityFrameworkCore
{
    public class VanhackTestDbContext : AbpZeroDbContext<Tenant, Role, User, VanhackTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseVideo> CourseVideos  { get; set; }
        public VanhackTestDbContext(DbContextOptions<VanhackTestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
