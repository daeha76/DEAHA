﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAEHA.GraphQL2nd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241226023122_Refactoring")]
    partial class Refactoring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.SessionAttendee", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<int>("AttendeeId")
                        .HasColumnType("integer");

                    b.HasKey("SessionId", "AttendeeId");

                    b.HasIndex("AttendeeId");

                    b.ToTable("SessionAttendee");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.SessionSpeaker", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("integer");

                    b.Property<int>("SpeakerId")
                        .HasColumnType("integer");

                    b.HasKey("SessionId", "SpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SessionSpeaker");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("GraphQL2nd.Data.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Website")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Session", b =>
                {
                    b.HasOne("DAEHA.GraphQL2nd.Data.Track", "Track")
                        .WithMany("Sessions")
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.SessionAttendee", b =>
                {
                    b.HasOne("DAEHA.GraphQL2nd.Data.Attendee", "Attendee")
                        .WithMany("SessionsAttendees")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAEHA.GraphQL2nd.Data.Session", "Session")
                        .WithMany("SessionAttendees")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.SessionSpeaker", b =>
                {
                    b.HasOne("DAEHA.GraphQL2nd.Data.Session", "Session")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQL2nd.Data.Speaker", "Speaker")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Attendee", b =>
                {
                    b.Navigation("SessionsAttendees");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Session", b =>
                {
                    b.Navigation("SessionAttendees");

                    b.Navigation("SessionSpeakers");
                });

            modelBuilder.Entity("DAEHA.GraphQL2nd.Data.Track", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("GraphQL2nd.Data.Speaker", b =>
                {
                    b.Navigation("SessionSpeakers");
                });
#pragma warning restore 612, 618
        }
    }
}