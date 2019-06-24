﻿// <auto-generated />
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Migrations
{
    [DbContext(typeof(ServerContext))]
    partial class ServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGHermes.SystemPerfomanceManagment.ServerAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DBConnectionString");

                    b.Property<string>("DisplayName");

                    b.Property<string>("IP");

                    b.Property<int>("Port");

                    b.Property<int>("ServiceStatus");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("EFGHermes.SystemPerfomanceManagment.ServerAPI.Models.ServiceRelationship", b =>
                {
                    b.Property<int>("FromServiceId");

                    b.Property<int>("ToServiceId");

                    b.HasKey("FromServiceId", "ToServiceId");

                    b.HasIndex("ToServiceId");

                    b.ToTable("ServiceRelationship");
                });

            modelBuilder.Entity("EFGHermes.SystemPerfomanceManagment.ServerAPI.Models.ServiceRelationship", b =>
                {
                    b.HasOne("EFGHermes.SystemPerfomanceManagment.ServerAPI.Models.Service", "FromService")
                        .WithMany("ServiceRelationships")
                        .HasForeignKey("FromServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGHermes.SystemPerfomanceManagment.ServerAPI.Models.Service", "ToService")
                        .WithMany()
                        .HasForeignKey("ToServiceId");
                });
#pragma warning restore 612, 618
        }
    }
}
