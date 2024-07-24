using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FaridV2.Authorization.Roles;
using FaridV2.Authorization.Users;
using FaridV2.MultiTenancy;
using FaridV2.Domain;
using FaridV2.Domains;
using Farid.Domains.LMS;
using Farid.Domains.WalletEntities;
using Farid.Domains;

namespace FaridV2.EntityFrameworkCore
{
    public class FaridV2DbContext : AbpZeroDbContext<Tenant, Role, User, FaridV2DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Package> Packages { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<HomeWorkComment> HomeWorkComments { get; set; }
        public DbSet<InternalPages> InternalPages { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<MeetAttendee> MeetAttendees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PackageTeacher> PackageTeachers { get; set; }
        public DbSet<QAndA> QAndAs { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserCertificate> UserCertificates { get; set; }
        public DbSet<UserExp> UserExps { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WorkShop> WorkShops { get; set; }




        public FaridV2DbContext(DbContextOptions<FaridV2DbContext> options)
            : base(options)
        {
        }
    }
}
