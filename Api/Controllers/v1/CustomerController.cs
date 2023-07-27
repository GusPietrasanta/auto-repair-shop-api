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
        [HttpGet(Name = "Get All Customers")]
        public async Task<ActionResult<List<ICustomerModel>>> Get()
        {
            try
            {
                var output = await _customerDataService.ReadAllCustomers();
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Customer failed");
                return BadRequest();
            }
        }

        // GET: api/v1/Customer/5
        [HttpGet("{id}", Name = "Get Single Customer")]
        public async Task<ActionResult<ICustomerModel>> Get(int id)
        {
            try
            {
                var output = await _customerDataService.ReadCustomerById(id);
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Customer/{Id} failed", id);
                return BadRequest();
            }
        }

        // POST: api/v1/Customer
        [HttpPost(Name = "Create New Customer")]
        public async Task<ActionResult<int>> Post([FromBody] CustomerModel newCustomer)
        {
            try
            {
                var output = await _customerDataService.CreateCustomer(newCustomer);
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The POST call to api/v1/Customer failed");
                return BadRequest();
            }
        }

        // PUT: api/v1/Customer/5
        [HttpPut("{id}", Name = "Update Customer")]
        public async Task<ActionResult> Put(int id, [FromBody] CustomerModel customerToUpdate)
        {
            if (id != customerToUpdate.Id)
            {
                _logger.LogError("The PUT call to api/v1/Customer/{Id} failed. Ids didn't match (Customer instance had Id {CustomerId})", id, customerToUpdate.Id);
                return BadRequest();
            }
            try
            {
                await _customerDataService.UpdateCustomer(customerToUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The PUT call to api/v1/Customer/{Id} failed", id);
                return BadRequest();
            }
        }

        // DELETE: api/v1/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _customerDataService.DeleteCustomerById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The DELETE call to api/v1/Customer/{Id} failed", id);
                return BadRequest();
            }
        }
    }
}
