﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentBuddyBackend.DAL;

#nullable disable

namespace RentBuddyBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.ApartmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CurrentFloor")
                        .HasColumnType("integer");

                    b.Property<int>("MaxFloor")
                        .HasColumnType("integer");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.BlacklistEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("BlacklistEntities");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.FavoriteRoomsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("FavoriteRoomsEntities");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.FavoriteUsersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("FavouritesEntities");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.RoomEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ApartmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FavoriteRoomsEntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InhabitantsCount")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Square")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("FavoriteRoomsEntityId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("BlacklistId")
                        .HasColumnType("uuid");

                    b.Property<int>("CommunicationLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FavoriteRoomsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FavoriteUsersId")
                        .HasColumnType("uuid");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("HasPet")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSmoke")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PureLevel")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RiseTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("SleepTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TimeSpentAtHome")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlacklistId");

                    b.HasIndex("FavoriteRoomsId");

                    b.HasIndex("FavoriteUsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.RoomEntity", b =>
                {
                    b.HasOne("RentBuddyBackend.DAL.Entities.ApartmentEntity", "Apartment")
                        .WithMany("Rooms")
                        .HasForeignKey("ApartmentId");

                    b.HasOne("RentBuddyBackend.DAL.Entities.FavoriteRoomsEntity", null)
                        .WithMany("Rooms")
                        .HasForeignKey("FavoriteRoomsEntityId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.UserEntity", b =>
                {
                    b.HasOne("RentBuddyBackend.DAL.Entities.BlacklistEntity", "Blacklist")
                        .WithMany("Users")
                        .HasForeignKey("BlacklistId");

                    b.HasOne("RentBuddyBackend.DAL.Entities.FavoriteRoomsEntity", "FavoriteRooms")
                        .WithMany()
                        .HasForeignKey("FavoriteRoomsId");

                    b.HasOne("RentBuddyBackend.DAL.Entities.FavoriteUsersEntity", "FavoriteUsers")
                        .WithMany("Users")
                        .HasForeignKey("FavoriteUsersId");

                    b.Navigation("Blacklist");

                    b.Navigation("FavoriteRooms");

                    b.Navigation("FavoriteUsers");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.ApartmentEntity", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.BlacklistEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.FavoriteRoomsEntity", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("RentBuddyBackend.DAL.Entities.FavoriteUsersEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
