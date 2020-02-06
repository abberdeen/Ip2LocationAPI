using Ip2LocationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationUpdate.Models
{
    public class GeolocationContext : DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=Hybrid;Username=postgres;Password=1;");
        }

        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<Address> Addresses { get; set; } 
    }
        
}
