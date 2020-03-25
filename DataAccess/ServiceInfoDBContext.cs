using Microsoft.EntityFrameworkCore;
using System;

namespace ServiceInfo.DataAccess
{
    public class ServiceInfoDBContext : DbContext
    {
        public ServiceInfoDBContext(DbContextOptions<ServiceInfoDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Converts ServiceState enum to string for storing and converts it back when returning data.
            modelBuilder
                .Entity<ServiceInfo>()
                .Property(s => s.ServiceState)
                .HasConversion(
                    x => x.ToString(),
                    x => (ServiceInfo.State)Enum.Parse(typeof(ServiceInfo.State), x));
        }

        public DbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
