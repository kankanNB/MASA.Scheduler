﻿// <auto-generated />
using System;
using Masa.Scheduler.Services.Server.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Masa.Scheduler.Services.Server.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    [Migration("20220507014827_SchedulerInit")]
    partial class SchedulerInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Masa.BuildingBlocks.Dispatcher.IntegrationEvents.Logs.IntegrationEventLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RowVersion")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimesSent")
                        .HasColumnType("int");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "EventId", "RowVersion" }, "index_eventid_version");

                    b.HasIndex(new[] { "State", "ModificationTime" }, "index_state_modificationtime");

                    b.HasIndex(new[] { "State", "TimesSent", "ModificationTime" }, "index_state_timessent_modificationtime");

                    b.ToTable("IntegrationEventLog", (string)null);
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlertMessageTemplate")
                        .HasColumnType("int");

                    b.Property<int>("BelongProjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("BelongTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("FailedRetryCount")
                        .HasColumnType("int");

                    b.Property<int>("FailedRetryInterval")
                        .HasColumnType("int");

                    b.Property<int>("FailedStrategy")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlertException")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("MainFunc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Principal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoutingStrategy")
                        .HasColumnType("int");

                    b.Property<int>("RunTimeoutSecond")
                        .HasColumnType("int");

                    b.Property<int>("RunTimeoutStrategy")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleBlockStrategy")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleExpiredStrategy")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BelongProjectId");

                    b.HasIndex("BelongTeamId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[IsDeleted] = 0");

                    b.ToTable("Job", "server");
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.JobRunDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LastRunStatus")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastRunTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("SuccessCount")
                        .HasColumnType("int");

                    b.Property<int>("TimeoutCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("JobRunDetail", "server");
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Resources.SchedulerResource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ResourceType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[IsDeleted] = 0");

                    b.ToTable("SchedulerResource", "server");
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Tasks.SchedulerTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RunCount")
                        .HasColumnType("int");

                    b.Property<long>("RunTime")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("TaskRunEndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("TaskRunStartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("SchedulerTask", "server");
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.JobRunDetail", b =>
                {
                    b.HasOne("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.Job", null)
                        .WithOne("RunDetail")
                        .HasForeignKey("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.JobRunDetail", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Tasks.SchedulerTask", b =>
                {
                    b.HasOne("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.Job", "Job")
                        .WithMany("SchedulerTasks")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.Job", b =>
                {
                    b.Navigation("RunDetail")
                        .IsRequired();

                    b.Navigation("SchedulerTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
