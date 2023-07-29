using System.Security.Claims;
using DataAccessLibrary.Data.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageDataService _messageDataService;
        private readonly ILogger<MessageController> _logger;

        public MessageController(IMessageDataService messageDataService, ILogger<MessageController> logger)
        {
            _messageDataService = messageDataService;
            _logger = logger;
        }
        
        // GET: api/v1/Message
        [HttpGet(Name = "Get All Messages")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<IMessageModel>>> Get()
        {        
            try
            {
                var output = await _messageDataService.ReadAllUnreadMessages();
                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The GET call to api/v1/Message failed");
                return BadRequest();
            }
        }
        

        // POST: api/v1/Message
        [HttpPost(Name = "Create a New Message")]
        [Authorize(Roles = "Mechanic")]
        public async Task<ActionResult> Post([FromBody] MessageModel newMessage)
        {
            if (newMessage.UserName != GetUserName())
            {
                _logger.LogError("The POST call to api/v1/Message failed. User Names didn't match");
                return BadRequest("User Names didn't match.");
            }
            try
            {
                await _messageDataService.CreateMessage(newMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The POST call to api/v1/Message failed");
                return BadRequest();
            }
        }

        // PUT: api/v1/Message/5/MarkAsRead
        [HttpPut("{id}/MarkAsRead", Name = "Mark Message As Read")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put(int id)
        {            
            try
            {
                await _messageDataService.MarkMessageAsRead(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The PUT call to api/v1/Message/{Id}/MarkAsRead failed", id);
                return BadRequest();
            }
        }

        private string GetUserName()
        {
            string userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;

            return userName;
        }
    }
}
