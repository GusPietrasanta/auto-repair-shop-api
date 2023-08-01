using DataAccessLibrary.Data.DataServices;
using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleDataService _vehicleDataService;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleDataService vehicleDataService, ILogger<VehicleController> logger)
        {
            _vehicleDataService = vehicleDataService;
            _logger = logger;
        }
        // GET: api/Vehicle
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/v1/Vehicle/5
        [HttpGet("{id}", Name = "Get Vehicle Details By Id")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var output = await _vehicleDataService.GetVehicleDetailsById(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Vehicle/{Id} failed", id);
                return BadRequest();
            }
        }

        // POST: api/Vehicle
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
