﻿// <auto-generated />
using System;
using Hoard.Data.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hoard.Data.Persistence.Migrations
{
    [DbContext(typeof(HoardDbContext))]
    [Migration("20210115185543_AddAlternateKeys")]
    partial class AddAlternateKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Hoard.Data.Entities.Game.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.HasAlternateKey("Title", "ReleaseDate");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ReleaseDate = new DateTime(2015, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Legend of Heroes: Trails in the Sky FC Evolution"
                        },
                        new
                        {
                            ID = 2,
                            ReleaseDate = new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Monster Hunter World"
                        },
                        new
                        {
                            ID = 3,
                            ReleaseDate = new DateTime(2015, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Yoshi's Woolly World"
                        });
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.PlayData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CurrentlyPlaying")
                        .HasColumnType("bit");

                    b.Property<bool>("Dropped")
                        .HasColumnType("bit");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("GameNotes")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("PlayNotes")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("GameID", "PlayerID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayData");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CurrentlyPlaying = true,
                            Dropped = false,
                            GameID = 1,
                            PlayerID = 1
                        },
                        new
                        {
                            ID = 2,
                            CurrentlyPlaying = false,
                            Dropped = true,
                            GameID = 1,
                            PlayerID = 2
                        },
                        new
                        {
                            ID = 3,
                            CurrentlyPlaying = false,
                            Dropped = false,
                            GameID = 2,
                            PlayerID = 1
                        },
                        new
                        {
                            ID = 4,
                            CurrentlyPlaying = true,
                            Dropped = false,
                            GameID = 2,
                            PlayerID = 2
                        },
                        new
                        {
                            ID = 5,
                            CurrentlyPlaying = true,
                            Dropped = false,
                            GameID = 3,
                            PlayerID = 1
                        },
                        new
                        {
                            ID = 6,
                            CurrentlyPlaying = false,
                            Dropped = true,
                            GameID = 3,
                            PlayerID = 2
                        });
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.PlayStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasAlternateKey("Name");

                    b.HasAlternateKey("OrdinalNumber");

                    b.ToTable("PlayStatuses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Playing",
                            OrdinalNumber = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "Finished",
                            OrdinalNumber = 2
                        },
                        new
                        {
                            ID = 3,
                            Name = "Hiatus",
                            OrdinalNumber = 3
                        },
                        new
                        {
                            ID = 4,
                            Name = "Dropped",
                            OrdinalNumber = 4
                        });
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ID");

                    b.HasAlternateKey("Name");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Meintje"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Bram"
                        });
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.Playthrough", b =>
                {
                    b.Property<int>("PlayDataID")
                        .HasColumnType("int");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("date");

                    b.Property<int>("PlayStatusID")
                        .HasColumnType("int");

                    b.Property<int>("PlaytimeMinutes")
                        .HasColumnType("int");

                    b.Property<bool>("SideContentCompleted")
                        .HasColumnType("bit");

                    b.HasKey("PlayDataID", "OrdinalNumber");

                    b.HasIndex("PlayStatusID");

                    b.ToTable("Playthroughs");

                    b.HasData(
                        new
                        {
                            PlayDataID = 1,
                            OrdinalNumber = 1,
                            DateEnd = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DateStart = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            PlayStatusID = 1,
                            PlaytimeMinutes = 3000,
                            SideContentCompleted = false
                        },
                        new
                        {
                            PlayDataID = 3,
                            OrdinalNumber = 1,
                            PlayStatusID = 3,
                            PlaytimeMinutes = 30000,
                            SideContentCompleted = false
                        },
                        new
                        {
                            PlayDataID = 4,
                            OrdinalNumber = 1,
                            DateEnd = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DateStart = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            PlayStatusID = 1,
                            PlaytimeMinutes = 29000,
                            SideContentCompleted = false
                        },
                        new
                        {
                            PlayDataID = 5,
                            OrdinalNumber = 1,
                            DateEnd = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DateStart = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            PlayStatusID = 2,
                            PlaytimeMinutes = 1000,
                            SideContentCompleted = true
                        },
                        new
                        {
                            PlayDataID = 5,
                            OrdinalNumber = 2,
                            DateEnd = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DateStart = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            PlayStatusID = 1,
                            PlaytimeMinutes = 500,
                            SideContentCompleted = false
                        },
                        new
                        {
                            PlayDataID = 6,
                            OrdinalNumber = 1,
                            DateEnd = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DateStart = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            PlayStatusID = 4,
                            PlaytimeMinutes = 10,
                            SideContentCompleted = false
                        });
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.PlayData", b =>
                {
                    b.HasOne("Hoard.Data.Entities.Game.Game", "Game")
                        .WithMany("PlayData")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hoard.Data.Entities.Game.Player", "Player")
                        .WithMany("GameProgress")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.Playthrough", b =>
                {
                    b.HasOne("Hoard.Data.Entities.Game.PlayData", "PlayData")
                        .WithMany("Playthroughs")
                        .HasForeignKey("PlayDataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hoard.Data.Entities.Game.PlayStatus", "PlayStatus")
                        .WithMany()
                        .HasForeignKey("PlayStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayData");

                    b.Navigation("PlayStatus");
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.Game", b =>
                {
                    b.Navigation("PlayData");
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.PlayData", b =>
                {
                    b.Navigation("Playthroughs");
                });

            modelBuilder.Entity("Hoard.Data.Entities.Game.Player", b =>
                {
                    b.Navigation("GameProgress");
                });
#pragma warning restore 612, 618
        }
    }
}