﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutoSeller.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AutomobileMake> AutomobileMakes { get; set; }
        public DbSet<AutomobileModel> AutomobileModels { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<AutomobileDetail> AutomobileDetails { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AspNetParameter> AspNetParameters { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}