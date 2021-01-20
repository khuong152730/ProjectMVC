using System;
using System.Collections.Generic;
using System.Text;

using Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Web.Data.Extensions
{
  public static  class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var rec1Id = new Guid("d7b7ce9e-f39f-4fea-9f2a-487a5355fbe9");
         
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator"
            });
          
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty,
                Lock=false,
                LastName = "Nguyễn Thanh",
                FirstName = "Bình",
                FullName= "Nguyễn Thanh Bình",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            }); 
        }
    }
}
