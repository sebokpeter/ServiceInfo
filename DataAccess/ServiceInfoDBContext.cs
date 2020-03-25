using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceInfo.DataAccess
{
    public class ServiceInfoDBContext : DbContext
    {
        public ServiceInfoDBContext() : base() { }

        public DbSet<ServiceInfo> ServiceInfos { get; set; }
    }
}
