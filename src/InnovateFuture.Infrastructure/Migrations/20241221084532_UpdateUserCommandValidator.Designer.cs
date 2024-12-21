﻿// <auto-generated />
using System;
using InnovateFuture.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InnovateFuture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241221084532_UpdateUserCommandValidator")]
    partial class UpdateUserCommandValidator
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Organisation", b =>
                {
                    b.Property<Guid>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("org_id");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("logo_url");

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("org_name");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Subscription")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("subscription");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<string>("WebsiteUrl")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("website_url");

                    b.HasKey("OrgId");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("profile_id");

                    b.Property<string>("Avatar")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<Guid?>("InvitedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("invited_by");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("uuid")
                        .HasColumnName("org_id");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("phone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SupervisedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("supervised_by");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("ProfileId");

                    b.HasIndex("InvitedBy")
                        .IsUnique();

                    b.HasIndex("OrgId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("SupervisedBy")
                        .IsUnique();

                    b.HasIndex("UserId", "RoleId", "OrgId")
                        .IsUnique()
                        .HasDatabaseName("IX_Profiles_user_id_role_id_org_id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<short>("CodeName")
                        .HasColumnType("smallint")
                        .HasColumnName("code_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<Guid>("CognitoUuid")
                        .HasMaxLength(500)
                        .HasColumnType("uuid")
                        .HasColumnName("cognito_uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("DefaultProfile")
                        .HasColumnType("uuid")
                        .HasColumnName("default_profile");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FamilyName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("family_name");

                    b.Property<string>("GivenName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("given_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("UserId");

                    b.HasIndex("CognitoUuid")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_cognito_uuid");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.Property<Guid>("InvitedProfilesProfileId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SupervisedProfilesProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("InvitedProfilesProfileId", "SupervisedProfilesProfileId");

                    b.HasIndex("SupervisedProfilesProfileId");

                    b.ToTable("ProfileProfile");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("InnovateFuture.Domain.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Profile", b =>
                {
                    b.HasOne("InnovateFuture.Domain.Entities.Profile", "InvitedByProfile")
                        .WithOne()
                        .HasForeignKey("InnovateFuture.Domain.Entities.Profile", "InvitedBy")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("InnovateFuture.Domain.Entities.Organisation", "Organisation")
                        .WithMany("Profiles")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnovateFuture.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InnovateFuture.Domain.Entities.Role", null)
                        .WithMany("Profiles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("InnovateFuture.Domain.Entities.Profile", "SupervisedByProfile")
                        .WithOne()
                        .HasForeignKey("InnovateFuture.Domain.Entities.Profile", "SupervisedBy")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("InnovateFuture.Domain.Entities.User", "User")
                        .WithMany("Profiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvitedByProfile");

                    b.Navigation("Organisation");

                    b.Navigation("Role");

                    b.Navigation("SupervisedByProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.HasOne("InnovateFuture.Domain.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("InvitedProfilesProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnovateFuture.Domain.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("SupervisedProfilesProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Organisation", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.Role", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("InnovateFuture.Domain.Entities.User", b =>
                {
                    b.Navigation("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}
