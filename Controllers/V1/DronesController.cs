using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using drones_api.Models;
using Microsoft.AspNetCore.Cors;
using drones_api.Services.Contracts;
using AutoMapper;

namespace drones_api.Data
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DronesController(IRepositoryManager repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // use transaction for drone battery modification

        /*        // GET: api/Drones
                [HttpGet]
                public async Task<ActionResult<IEnumerable<Drone>>> GetDrone()
                {
                    return await _context.Drone.ToListAsync();
                }

                // GET: api/Drones/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Drone>> GetDrone(Guid id)
                {
                    var drone = await _context.Drone.FindAsync(id);

                    if (drone == null)
                    {
                        return NotFound();
                    }

                    return drone;
                }

                // PUT: api/Drones/5
                // To protect from overposting attacks, enable the specific properties you want to bind to, for
                // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
                [HttpPut("{id}")]
                public async Task<IActionResult> PutDrone(Guid id, Drone drone)
                {
                    if (id != drone.SerialNumber)
                    {
                        return BadRequest();
                    }

                    _context.Entry(drone).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DroneExists(id))
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

                // POST: api/Drones
                // To protect from overposting attacks, enable the specific properties you want to bind to, for
                // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
                [HttpPost]
                public async Task<ActionResult<Drone>> PostDrone(Drone drone)
                {
                    _context.Drone.Add(drone);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetDrone", new { id = drone.SerialNumber }, drone);
                }

                // DELETE: api/Drones/5
                [HttpDelete("{id}")]
                public async Task<ActionResult<Drone>> DeleteDrone(Guid id)
                {
                    var drone = await _context.Drone.FindAsync(id);
                    if (drone == null)
                    {
                        return NotFound();
                    }

                    _context.Drone.Remove(drone);
                    await _context.SaveChangesAsync();

                    return drone;
                }

                private bool DroneExists(Guid id)
                {
                    return _context.Drone.Any(e => e.SerialNumber == id);
                }*/
    }
}
