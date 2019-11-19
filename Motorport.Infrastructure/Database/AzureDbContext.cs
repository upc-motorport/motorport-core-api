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
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MechanicalWorkshop> MechanicalWorkshops { get; set; }

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

            builder
                .Entity<Membership>()
                .Property(m => m.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (RoleEnum)Enum.Parse(typeof(RoleEnum), v));

            builder
                .Entity<Plan>()
                .Property(p => p.PlanType)
                .HasConversion(
                    v => v.ToString(),
                    v => (PlanTypeEnum)Enum.Parse(typeof(PlanTypeEnum),v));
            
            // Mock Data

            builder.Entity<Plan>()
                .HasData(
                    new
                    {
                        Id = 1,
                        Name = "Basic",
                        Description = "Basic Plan",
                        Cost = 0.0,
                        UsersLimit = 1,
                        PlanType = PlanTypeEnum.Basic,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    }
                );

            builder.Entity<Subscription>()
                .HasData(
                    new
                    {
                        Id = 1,
                        PlanId = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    }
                );

            builder.Entity<User>()
                .HasData(
                    new
                    {
                        Id = 1,
                        Email = "alvarado.manuel@live.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("Motor2019"),
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    }
                );

            builder.Entity<Person>()
                .HasData(
                    new
                    {
                        Id = 1,
                        FirstName = "Manuel Augusto",
                        LastName = "Alvarado Estanga",
                        ShortName = "Manuel Alvarado",
                        IdentificationNumber = "81058541",
                        UserId = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    }
                );

            builder.Entity<Membership>()
                .HasData(
                    new
                    {
                        Id = 1,
                        StartDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddMonths(12),
                        Role = RoleEnum.Owner,
                        SubscriptionId = 1,
                        UserId = 1,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    }
                );

            builder.Entity<Vehicle>()
                .HasData(
                    new
                    {
                        Id = 1,
                        SubscriptionId = 1,
                        RegistrationPlate = "ABC123",
                        Brand = "Chevrolet",
                        Model = "Camaro",
                        Type = "Car",
                        Year = 2014,
                        Kilometers = 0,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    },
                    new
                    {
                        Id = 2,
                        SubscriptionId = 1,
                        RegistrationPlate = "DCE321",
                        Brand = "Chevrolet",
                        Model = "Bolt",
                        Type = "Car",
                        Year = 2014,
                        Kilometers = 0,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Active = true
                    });

            builder.Entity<Organization>().HasData(
                new {
                    Id = 1,
                    Ruc = "1002419",
                    BussinessName = "MotorPort SAC",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Active = true
                }
                    
                
                );
            builder.Entity<MechanicalWorkshop>().HasData(
                new
                {
                    Id = 1,
                    OrganizationId = 1,
                    Name = "AutoData S.A.C",
                    Street = "Las Casuarinas",
                    StreetNumber = "231",
                    ZipCode = "15023",
                    City = "Lima",
                    AverageRate = 4.0,
                    Department = "Santiago de Surco",
                    Country = "Peru",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Active = true
                },
                new
                {
                    Id = 2,
                    OrganizationId = 1,
                    Name = "AutoSolution",
                    Street = "Mariano Eduardo de Rivero y Ustariz",
                    StreetNumber = "123",
                    ZipCode = "15023",
                    City = "Lima",
                    AverageRate = 4.5,
                    Department = "Santiago de Surco",
                    Country = "Peru",
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Active = true
                }



                );

        }
    }
}
