﻿// <auto-generated />
using Celebrity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Celebrity.Data.Migrations
{
    [DbContext(typeof(CelebrityDataContext))]
    partial class CelebrityDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Celebrity.Data.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Celebrity.Data.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ApiToken")
                        .HasMaxLength(128);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Celebrity.Data.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Celebrity.Data.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.Property<string>("Website")
                        .HasMaxLength(2083);

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Celebrity.Data.Models.OrganizationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganizationUsers");
                });

            modelBuilder.Entity("Celebrity.Data.Models.WebHook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid>("OrganizationId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2083);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("WebHooks");
                });

            modelBuilder.Entity("Celebrity.Data.Models.WebHookParameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateCreated");

                    b.Property<DateTimeOffset?>("DateModified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(254);

                    b.Property<string>("UserModified")
                        .HasMaxLength(254);

                    b.Property<string>("Value");

                    b.Property<Guid>("WebHookId");

                    b.HasKey("Id");

                    b.HasIndex("WebHookId");

                    b.ToTable("WebHookParameter");
                });

            modelBuilder.Entity("Celebrity.Data.Models.Identity.UserRole", b =>
                {
                    b.HasOne("Celebrity.Data.Models.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Celebrity.Data.Models.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Celebrity.Data.Models.OrganizationUser", b =>
                {
                    b.HasOne("Celebrity.Data.Models.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Celebrity.Data.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Celebrity.Data.Models.WebHook", b =>
                {
                    b.HasOne("Celebrity.Data.Models.Organization")
                        .WithMany("WebHooks")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Celebrity.Data.Models.WebHookParameter", b =>
                {
                    b.HasOne("Celebrity.Data.Models.WebHook")
                        .WithMany("Parameters")
                        .HasForeignKey("WebHookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
