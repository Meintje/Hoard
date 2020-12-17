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
    [Migration("20201217060730_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.PlayStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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
                            Name = "Not started",
                            OrdinalNumber = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "Playing",
                            OrdinalNumber = 2
                        },
                        new
                        {
                            ID = 3,
                            Name = "Finished",
                            OrdinalNumber = 3
                        });
                });

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

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

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.PlayerProgress", b =>
                {
                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("PlayStatusID")
                        .HasColumnType("int");

                    b.HasKey("GameID", "PlayerID");

                    b.HasIndex("PlayStatusID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayerProgress");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            PlayerID = 1,
                            PlayStatusID = 2
                        },
                        new
                        {
                            GameID = 1,
                            PlayerID = 2,
                            PlayStatusID = 1
                        },
                        new
                        {
                            GameID = 2,
                            PlayerID = 1,
                            PlayStatusID = 2
                        },
                        new
                        {
                            GameID = 2,
                            PlayerID = 2,
                            PlayStatusID = 2
                        },
                        new
                        {
                            GameID = 3,
                            PlayerID = 1,
                            PlayStatusID = 3
                        },
                        new
                        {
                            GameID = 3,
                            PlayerID = 2,
                            PlayStatusID = 3
                        });
                });

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.PlayerProgress", b =>
                {
                    b.HasOne("Hoard.Data.Persistence.Entities.Game", "Game")
                        .WithMany("PlayerProgress")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hoard.Data.Persistence.Entities.PlayStatus", "PlayStatus")
                        .WithMany()
                        .HasForeignKey("PlayStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hoard.Data.Persistence.Entities.Player", "Player")
                        .WithMany("GameProgress")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("PlayStatus");
                });

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.Game", b =>
                {
                    b.Navigation("PlayerProgress");
                });

            modelBuilder.Entity("Hoard.Data.Persistence.Entities.Player", b =>
                {
                    b.Navigation("GameProgress");
                });
#pragma warning restore 612, 618
        }
    }
}