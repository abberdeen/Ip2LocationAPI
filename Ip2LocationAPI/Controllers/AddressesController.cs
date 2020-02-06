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
    public class AddressesController : ControllerBase
    {
        private readonly GeolocationContext _context;

        public AddressesController(GeolocationContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public  ActionResult<String> GetAddresses()
        {
            return "Use POST method";
        }

        // GET: api/Addresses
        [HttpPost]
        public ActionResult<Address> GetAddresses([FromBody] UserData data)
        {
            IPAddress ipAddress = null;
            IPAddress.TryParse(data.Ip, out ipAddress);
            if (ipAddress == null)
            {
                return BadRequest();
            }
            var geolocation = _context.Geolocations.Where(b => EF.Functions.Contains( b.Network  , ipAddress)).FirstOrDefault();
            if (geolocation == null)
            {
                return NotFound();
            }

            var address = _context.Addresses.Find(geolocation.GeonameId);
            if (address == null)
            {
                return NotFound();
            }

            address.Geolocation = geolocation;
            return address;
        }


    }
}
