using System.Security.Claims;
using DataAccessLibrary.Data.DataServices;
using DataAccessLibrary.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDataService _appointmentDataService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentDataService appointmentDataService, ILogger<AppointmentController> logger)
        {
            _appointmentDataService = appointmentDataService;
            _logger = logger;
        }
        
        // Mechanic Endpoints
        
        // GET: api/Appointment/Count
        [HttpGet("Count", Name = "Get Today's Appointment Count For This Mechanic")]
        [Authorize(Roles = "Mechanic")]
        public async Task<ActionResult<int>> GetCount()
        {
            try
            {
                var output = await _appointmentDataService.GetTodayAppointmentsCountByUserName(GetMechanicUserName());
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/Appointment/Count failed");
                return BadRequest();
            }
        }    
        
        // GET: api/Appointment/
        [HttpGet(Name = "Get Today's Appointments For This Mechanic")]
        [Authorize(Roles = "Mechanic")]
        public async Task<ActionResult<int>> Get()
        {
            try
            {
                var output = await _appointmentDataService.ReadAllAppointmentsDetailedByUserName(GetMechanicUserName());
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/Appointment/Count failed");
                return BadRequest();
            }
        }
        
        

        // GET: api/Appointment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Appointment
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string GetMechanicId()
        {
            string mechanicId = User.Claims.FirstOrDefault(c => c.Type == "MechanicId")!.Value;

            return mechanicId;
        }

        private string GetMechanicUserName()
        {
            string userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;

            return userName;
        }
    }
}
