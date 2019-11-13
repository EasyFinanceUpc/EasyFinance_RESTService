﻿// <auto-generated />
using System;
using EasyFinanceApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyFinanceApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("Create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Key = "2c8bab3c-6050-4247-bba0-77777b088388",
                            Payment = true
                        });
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.AccountSubscription", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnName("Account_Id")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnName("Subscription_Id")
                        .HasColumnType("int");

                    b.Property<int>("MembershipId")
                        .HasColumnName("Membership_Id")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "SubscriptionId", "MembershipId");

                    b.HasIndex("MembershipId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("AccountSubscriptions");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvisorId")
                        .HasColumnName("Advisor_Id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvisorId")
                        .HasColumnName("Advisor_Id")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(8000);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("Create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndAt")
                        .HasColumnName("End_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartAt")
                        .HasColumnName("Start_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Registry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CategoryId")
                        .HasColumnName("Category_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnName("Create_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnName("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Registries");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Registry");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("NumberUser")
                        .HasColumnName("Number_User")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Free",
                            NumberUser = 1,
                            Price = 0.00m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Micro Entrepreneur",
                            NumberUser = 6,
                            Price = 12.90m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Entrepreneur",
                            NumberUser = 20,
                            Price = 35.90m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Advisor",
                            NumberUser = 1,
                            Price = 6.90m
                        });
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnName("Account_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnName("Last_Name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Budget", b =>
                {
                    b.HasBaseType("EasyFinanceApi.Domain.Models.Registry");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Budget");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Goal", b =>
                {
                    b.HasBaseType("EasyFinanceApi.Domain.Models.Registry");

                    b.Property<DateTime>("ReachAt")
                        .HasColumnName("Reach_At")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Goal");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Movement", b =>
                {
                    b.HasBaseType("EasyFinanceApi.Domain.Models.Registry");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Movement");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Advisor", b =>
                {
                    b.HasBaseType("EasyFinanceApi.Domain.Models.User");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasDiscriminator().HasValue("Advisor");
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Customer", b =>
                {
                    b.HasBaseType("EasyFinanceApi.Domain.Models.User");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Active = true,
                            Email = "julio@gmail.com",
                            Gender = 1,
                            LastName = "Gomez",
                            Name = "Julio",
                            Password = "123456",
                            Role = 1,
                            Birthday = new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.AccountSubscription", b =>
                {
                    b.HasOne("EasyFinanceApi.Domain.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyFinanceApi.Domain.Models.Membership", "Membership")
                        .WithMany()
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyFinanceApi.Domain.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Appointment", b =>
                {
                    b.HasOne("EasyFinanceApi.Domain.Models.Advisor", "Advisor")
                        .WithMany("Appointments")
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyFinanceApi.Domain.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Article", b =>
                {
                    b.HasOne("EasyFinanceApi.Domain.Models.Advisor", "Advisor")
                        .WithMany("Articles")
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.Registry", b =>
                {
                    b.HasOne("EasyFinanceApi.Domain.Models.Category", "Category")
                        .WithMany("Registries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyFinanceApi.Domain.Models.Customer", "Customer")
                        .WithMany("Registries")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinanceApi.Domain.Models.User", b =>
                {
                    b.HasOne("EasyFinanceApi.Domain.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
