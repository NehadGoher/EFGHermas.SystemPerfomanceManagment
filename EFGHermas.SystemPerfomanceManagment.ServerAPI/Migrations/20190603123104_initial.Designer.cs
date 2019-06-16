﻿// <auto-generated />
using System;
using EFGHermas.SystemPerfomanceManagment.ServerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGHermas.SystemPerfomanceManagment.ServerAPI.Migrations
{
    [DbContext(typeof(ServerContext))]
    [Migration("20190603123104_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Database", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionString");

                    b.Property<int?>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("Database");
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.EndPoint", b =>
                {
                    b.Property<int>("ServiceId");

                    b.Property<string>("Address");

                    b.Property<string>("Protocol");

                    b.HasKey("ServiceId", "Address");

                    b.ToTable("EndPoint");
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<int>("ServiceStatus");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.ServiceRelationship", b =>
                {
                    b.Property<int>("FromServiceId");

                    b.Property<int>("ToServiceId");

                    b.HasKey("FromServiceId", "ToServiceId");

                    b.HasIndex("ToServiceId");

                    b.ToTable("ServiceRelationship");
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Database", b =>
                {
                    b.HasOne("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Service")
                        .WithMany("Databases")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.EndPoint", b =>
                {
                    b.HasOne("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Service")
                        .WithMany("EndPoints")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.ServiceRelationship", b =>
                {
                    b.HasOne("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Service", "FromService")
                        .WithMany("OutboundServices")
                        .HasForeignKey("FromServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGHermas.SystemPerfomanceManagment.ServerAPI.Models.Service", "ToService")
                        .WithMany()
                        .HasForeignKey("ToServiceId");
                });
#pragma warning restore 612, 618
        }
    }
}
