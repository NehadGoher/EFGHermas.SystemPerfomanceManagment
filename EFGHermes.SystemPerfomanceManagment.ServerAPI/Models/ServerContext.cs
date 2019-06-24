using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ServiceRelationship>()
                .HasKey(s => new { s.FromServiceId, s.ToServiceId });

            modelBuilder.Entity<ServiceRelationship>()
                .HasOne(s => s.FromService)
                .WithMany(s => s.OutgoingServices)
                .HasForeignKey(s => s.FromServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ServiceRelationship>()
                .HasOne(s => s.ToService)
                .WithMany(s => s.IngoingServices)
                .HasForeignKey(s => s.ToServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<Service> Services { get; set; }
    }
}
