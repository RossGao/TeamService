﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TeamService.Models;

namespace TeamService.Migrations
{
    [DbContext(typeof(TeamContext))]
    [Migration("20180518020342_CreateTeam&Member")]
    partial class CreateTeamMember
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("TeamService.Models.LocationRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<Guid>("MemberID");

                    b.Property<float>("TimeStamp");

                    b.HasKey("ID");

                    b.HasIndex("MemberID")
                        .IsUnique();

                    b.ToTable("LocationRecord");
                });

            modelBuilder.Entity("TeamService.Models.Member", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TeamService.Models.Team", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamService.Models.LocationRecord", b =>
                {
                    b.HasOne("TeamService.Models.Member")
                        .WithOne("Location")
                        .HasForeignKey("TeamService.Models.LocationRecord", "MemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TeamService.Models.Member", b =>
                {
                    b.HasOne("TeamService.Models.Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamID");
                });
#pragma warning restore 612, 618
        }
    }
}
