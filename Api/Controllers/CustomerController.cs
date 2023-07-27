using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerDataService customerDataService, ILogger<CustomerController> logger)
        {
            _customerDataService = customerDataService;
            _logger = logger;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<List<ICustomerModel>>> Get()
        {
            var output = await _customerDataService.ReadAllCustomers();
            return Ok(output);
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
