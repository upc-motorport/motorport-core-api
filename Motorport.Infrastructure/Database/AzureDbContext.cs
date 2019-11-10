using Microsoft.EntityFrameworkCore;
using Motorport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Infrastructure.Database
{
    public class AzureDbContext: DbContext
    {
        public AzureDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<Person>(p => p.UserId);

            builder.Entity<User>()
                .HasOne(u => u.Membership)
                .WithOne(m => m.User)
                .HasForeignKey<Membership>(m => m.UserId);
        }
    }
}
