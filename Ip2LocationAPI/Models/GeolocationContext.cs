using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationAPI.Models
{
    public class GeolocationContext : DbContext
    {
        public GeolocationContext(DbContextOptions<GeolocationContext> options) : base(options)
        {
        }
  
        public DbSet<Geolocation> Geolocations { get; set; }
        public DbSet<Address> Addresses { get; set; } 
    }
        
}
