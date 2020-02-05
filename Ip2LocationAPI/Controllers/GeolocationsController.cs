using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ip2LocationAPI.Models;
using System.Net;

namespace Ip2LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationsController : ControllerBase
    {
        private readonly GeolocationContext _context;

        public GeolocationsController(GeolocationContext context)
        {
            _context = context;
        }

        // GET: api/Geolocations
        [HttpGet]
        public ActionResult<String> GetGeolocations()
        {
            return "Use POST method";
        }

        // GET: api/Geolocations
        [HttpPost]
        public ActionResult<Geolocation> GetGeolocation([FromBody] UserData data)
        {
            IPAddress ipAddress=null;
            IPAddress.TryParse(data.Ip, out ipAddress);
            if (ipAddress == null)
            {
                BadRequest(  );
            } 
            var geolocation = _context.Geolocations.Where(b => EF.Functions.Contains(b.Network,ipAddress)).First();
            if (geolocation == null)
            {
                NotFound();
            }

            return geolocation;
        }
         
    }
}
