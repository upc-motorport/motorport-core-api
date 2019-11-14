﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motorport.Infrastructure.Database;

namespace Motorport.Infrastructure.Migrations
{
    [DbContext(typeof(AzureDbContext))]
    [Migration("20191110051824_UpdatedSubscription")]
    partial class UpdatedSubscription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Motorport.Domain.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<int>("Role");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("SubscriptionId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Motorport.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("IdentificationNumber")
                        .HasMaxLength(20);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<string>("MyProperty")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Motorport.Domain.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<decimal>("Cost")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PlanType");

                    b.Property<int>("UsersLimit");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Motorport.Domain.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<int>("PlanId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Motorport.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Motorport.Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200);

                    b.Property<int>("Kilometers");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50);

                    b.Property<int>("RegistrationPlate");

                    b.Property<int>("SubscriptionId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Motorport.Domain.Models.Membership", b =>
                {
                    b.HasOne("Motorport.Domain.Models.Subscription", "Subscription")
                        .WithMany("Memberships")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motorport.Domain.Models.User", "User")
                        .WithOne("Membership")
                        .HasForeignKey("Motorport.Domain.Models.Membership", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motorport.Domain.Models.Person", b =>
                {
                    b.HasOne("Motorport.Domain.Models.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("Motorport.Domain.Models.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motorport.Domain.Models.Subscription", b =>
                {
                    b.HasOne("Motorport.Domain.Models.Plan", "Plan")
                        .WithMany("Subscriptions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motorport.Domain.Models.Vehicle", b =>
                {
                    b.HasOne("Motorport.Domain.Models.Subscription", "Subscription")
                        .WithMany("Vehicles")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
