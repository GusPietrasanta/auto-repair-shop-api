using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        // GET: api/Appointment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
    }
}
