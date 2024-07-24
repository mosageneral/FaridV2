using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using FaridV2.Authorization;
using FaridV2.Authorization.Roles;
using FaridV2.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FaridV2.EntityFrameworkCore.Seed.Host
{
    public class HostRoleAndUserCreator
    {
        private readonly FaridV2DbContext _context;

        public HostRoleAndUserCreator(FaridV2DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {
            // Admin role for host

            var adminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Admin, StaticRoleNames.Host.Admin) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }
            // SuperAdmin role for host

            var SuperadminRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.SuperAdmin);
            if (SuperadminRoleForHost == null)
            {
                SuperadminRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.SuperAdmin, StaticRoleNames.Host.SuperAdmin) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }
            // Parent role for host

            var ParentRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Parent);
            if (ParentRoleForHost == null)
            {
                ParentRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Parent, StaticRoleNames.Host.Parent) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }

            // Teacher role for host

            var TeacherRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Teacher);
            if (TeacherRoleForHost == null)
            {
                TeacherRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Teacher, StaticRoleNames.Host.Teacher) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }
            // Student role for host

            var StudentRoleForHost = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Student);
            if (StudentRoleForHost == null)
            {
                StudentRoleForHost = _context.Roles.Add(new Role(null, StaticRoleNames.Host.Student, StaticRoleNames.Host.Student) { IsStatic = true, IsDefault = true }).Entity;
                _context.SaveChanges();
            }


            // Grant all permissions to admin role for host

            var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == null && p.RoleId == adminRoleForHost.Id)
                .Select(p => p.Name)
                .ToList();

            var permissions = PermissionFinder
                .GetAllPermissions(new FaridV2AuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host) &&
                            !grantedPermissions.Contains(p.Name))
                .ToList();

            if (permissions.Any())
            {
                _context.Permissions.AddRange(
                    permissions.Select(permission => new RolePermissionSetting
                    {
                        TenantId = null,
                        Name = permission.Name,
                        IsGranted = true,
                        RoleId = adminRoleForHost.Id
                    })
                );
                _context.SaveChanges();
            }
            // Grant all permissions to Superadmin role for host

            var SuperadmingrantedPermissions = _context.Permissions.IgnoreQueryFilters()
                .OfType<RolePermissionSetting>()
                .Where(p => p.TenantId == null && p.RoleId == SuperadminRoleForHost.Id)
                .Select(p => p.Name)
                .ToList();

            var Superadminpermissions = PermissionFinder
                .GetAllPermissions(new FaridV2AuthorizationProvider())
                .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host) &&
                            !SuperadmingrantedPermissions.Contains(p.Name))
                .ToList();

            if (Superadminpermissions.Any())
            {
                _context.Permissions.AddRange(
                    Superadminpermissions.Select(Superadminpermission => new RolePermissionSetting
                    {
                        TenantId = null,
                        Name = Superadminpermission.Name,
                        IsGranted = true,
                        RoleId = SuperadminRoleForHost.Id
                    })
                );
                _context.SaveChanges();
            }

            // Admin user for host

            var adminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == AbpUserBase.AdminUserName);
            if (adminUserForHost == null)
            {
                var user = new User
                {
                    TenantId = null,
                    UserName = AbpUserBase.AdminUserName,
                    Name = "admin",
                    Surname = "admin",
                    EmailAddress = "admin@aspnetboilerplate.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                adminUserForHost = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));
                _context.SaveChanges();

                _context.SaveChanges();
            }

            // SuperAdmin user for host

            var SuperadminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == null && u.UserName == "SuperAdmin");
            if (SuperadminUserForHost == null)
            {
                var user = new User
                {
                    TenantId = null,
                    UserName = AbpUserBase.AdminUserName,
                    Name = "SuperAdmin",
                    Surname = "SuperAdmin",
                    EmailAddress = "SuperAdmin@SuperAdmin.com",
                    IsEmailConfirmed = true,
                    IsActive = true
                };

                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "123qwe");
                user.SetNormalizedNames();

                SuperadminUserForHost = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(null, SuperadminUserForHost.Id, SuperadminRoleForHost.Id));
                _context.SaveChanges();

                _context.SaveChanges();
            }
        }
    }
}
