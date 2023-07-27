using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerDataService customerDataService, ILogger<CustomerController> logger)
        {
            _customerDataService = customerDataService;
            _logger = logger;
        }

        // GET: api/v1/Customer
        [HttpGet]
        public async Task<ActionResult<List<ICustomerModel>>> Get()
        {
            var output = await _customerDataService.ReadAllCustomers();
            return Ok(output);
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ICustomerModel>> Get(int id)
        {
            var output = await _customerDataService.ReadCustomerById(id);
            return Ok(output);
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
