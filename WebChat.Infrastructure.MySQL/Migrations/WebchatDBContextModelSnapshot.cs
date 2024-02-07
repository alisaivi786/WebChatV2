﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebChat.Presistence.DBContext;

#nullable disable

namespace WebChat.Infrastructure.MySQL.Migrations
{
    [DbContext(typeof(WebchatDBContext))]
    partial class WebchatDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebChat.Domain.Entities.GroupEntitiy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Group");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7175),
                            IsActive = true,
                            Name = "TB-Admin"
                        });
                });

            modelBuilder.Entity("WebChat.Domain.Entities.GroupUsersEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("WebChat.Domain.Entities.MessageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Content = "Hello Team",
                            CreatedBy = 1L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7234),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Content = "Hey Ali!",
                            CreatedBy = 2L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7236),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            Content = "I am Fine Poonam what about you?",
                            CreatedBy = 1L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7268),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            Content = "Good to hear you are good, thanks for asking i am also fine!.",
                            CreatedBy = 2L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7269),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            Content = "hey Guys whats the update of our chat v1 Project???.",
                            CreatedBy = 3L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7271),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3L
                        },
                        new
                        {
                            Id = 6L,
                            Content = "Architecture of Project is done just doing some final tweaks and then update you here in group.",
                            CreatedBy = 1L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7272),
                            GroupId = 1L,
                            IsActive = true,
                            SentTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("WebChat.Domain.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 1L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7033),
                            IsActive = true,
                            PhoneNumber = "971505679899",
                            UserName = "Ali"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = 2L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7041),
                            IsActive = true,
                            PhoneNumber = "971505679800",
                            UserName = "Poonam"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedBy = 3L,
                            DateCreated = new DateTime(2024, 2, 5, 12, 29, 1, 480, DateTimeKind.Utc).AddTicks(7042),
                            IsActive = true,
                            PhoneNumber = "971505679888",
                            UserName = "Aymen"
                        });
                });

            modelBuilder.Entity("WebChat.Domain.Entities.GroupUsersEntity", b =>
                {
                    b.HasOne("WebChat.Domain.Entities.GroupEntitiy", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebChat.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebChat.Domain.Entities.MessageEntity", b =>
                {
                    b.HasOne("WebChat.Domain.Entities.GroupEntitiy", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebChat.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
