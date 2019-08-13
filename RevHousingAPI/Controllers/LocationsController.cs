using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RHEntities;
using RevHousingAPI;
using Microsoft.AspNetCore.Cors;
using RevHousingAPI.Data;
using RevHousingAPI.IRepositories;
using RevHousingAPI.Repositories;
using System.Net;

namespace RevHousingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        // GET: api/locations
        [HttpGet]
        public ActionResult<IEnumerable<Location>> Getlocations()
        {
            return locationRepository.GetAll().ToList();
        }

        // GET: api/locations/5
        [HttpGet("{id}")]
        public ActionResult<Location> Getlocation(int id)
        {
            var location = locationRepository.Get(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/locations/5
        [HttpPut("{id}")]
        public IActionResult Putlocation(int id, Location location)
        {
            if (id != location.LocationID)
            {
                return BadRequest();
            }

            try
            {
                locationRepository.Update(location);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/locations
        [HttpPost]
        public ActionResult<Location> Postlocation(Location location)
        {
            locationRepository.Add(location);
            return CreatedAtAction("Getlocation", new { id = location.LocationID }, location);
        }

        private bool locationExists(int id)
        {
            return locationRepository.GetAll().Any(e => e.LocationID == id);
        }
    }

}
