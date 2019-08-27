using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SmartCompany.Authorization.Roles;
using SmartCompany.Authorization.Users;
using SmartCompany.MultiTenancy;
using SmartCompany.Entities;

namespace SmartCompany.EntityFrameworkCore
{
    public class SmartCompanyDbContext : AbpZeroDbContext<Tenant, Role, User, SmartCompanyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Department> Departments { set; get; }
        public SmartCompanyDbContext(DbContextOptions<SmartCompanyDbContext> options)
            : base(options)
        {
        }
    }
}
