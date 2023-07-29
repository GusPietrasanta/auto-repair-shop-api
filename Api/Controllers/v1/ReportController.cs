using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ReportController : ControllerBase
    {
        private readonly IReportDataService _reportDataService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IReportDataService reportDataService, ILogger<ReportController> logger)
        {
            _reportDataService = reportDataService;
            _logger = logger;
        }
        
        // GET: api/v1/Report/Dashboard/NonArchived
        [HttpGet("Dashboard/Active", Name = "Get Only Active Reports With Vehicle And Customer Information")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IDashboardReportModel>>> GetNonArchived()
        {
            try
            {
                var output = await _reportDataService.SearchActiveReportsDashboard();
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Dashboard failed");
                return BadRequest();
            }
        }             
        
        // GET: api/v1/Report/Dashboard/All
        [HttpGet("Dashboard/All", Name = "Get ALL Reports With Vehicle And Customer Information")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IDashboardReportModel>>> GetAll()
        {
            try
            {
                var output = await _reportDataService.SearchAllReportsDashboard();
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Dashboard failed");
                return BadRequest();
            }
        }          
        
        // GET: api/v1/ReportVehicle/5
        [HttpGet("Vehicle/{vehicleId}", Name = "Get Full Reports By Vehicle ID")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IDashboardReportModel>>> GetByVehicle(int vehicleId)
        {
            try
            {
                var output = await _reportDataService.GetReportsByVehicleId(vehicleId);
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Vehicle/{VehicleId} failed", vehicleId);
                return BadRequest();
            }
        }     
                
        // GET: api/v1/Report/Dashboard/Offset/15/Fetch/3
        [HttpGet("Dashboard/Offset/{offset}/Fetch/{fetch}", Name = "Get Paginated Reports")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IDashboardReportModel>>> Get(int offset, int fetch)
        {
            try
            {
                var output = await _reportDataService.GetReportsPagination(offset, fetch);
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Dashboard/{Offset}/15/Fetch/{Fetch} failed", offset, fetch);
                return BadRequest();
            }
        }                   
        
        // GET: api/v1/Report/Count
        [HttpGet("Count", Name = "Get Reports Count")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<int>> GetCount()
        {
            try
            {
                var output = await _reportDataService.GetReportsCount();
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Dashboard/Count");
                return BadRequest();
            }
        }     
        
        // GET: api/v1/Report/5
        [HttpGet("{id}", Name = "Get Single Full Report")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IFullReportModel>>> Get(int id)
        {
            try
            {
                var output = await _reportDataService.GetFullReportFromId(id);
                if (output == null)
                {
                    _logger.LogError("The GET call to api/v1/Report/{Id} failed. No report found with such ID", id);
                    return NotFound("No report found with that ID.");
                }
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/{Id} failed", id);
                return BadRequest();
            }
        }

        
        // POST: api/v1/Report
        [HttpPost(Name = "Create A New Report")]
        [Authorize(Roles = "Mechanic")]
        public async Task<ActionResult> Post([FromBody] ReportModel newReport)
        {            
            try
            {
                await _reportDataService.CreateReport(newReport);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The POST call to api/v1/Report/ failed");
                return BadRequest();
            }
            
        }

        // PUT: api/v1/Report/Archive/5
        [HttpPut("Archive/{id}", Name = "Archive A Report By ID")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put(int id)
        {
            try
            {
                await _reportDataService.ArchiveInspection(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Report/Archive/{Id} failed", id);
                return BadRequest();
            }
        }
    }
}
