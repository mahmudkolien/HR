﻿// <auto-generated />
using System;
using HR.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR.Repository.Migrations
{
    [DbContext(typeof(HRDbContext))]
    [Migration("20190724082744_SeedUserData")]
    partial class SeedUserData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HR.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<Guid?>("CreatedById");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Gender");

                    b.Property<string>("ImageFile");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastPassChangeDate");

                    b.Property<string>("LastPassword");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEndDateUtc");

                    b.Property<string>("Mobile");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("PasswordChangedCount");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("Status");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HR.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedById");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.Property<int?>("Status");

                    b.Property<Guid?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("HR.Entities.User", b =>
                {
                    b.HasOne("HR.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}