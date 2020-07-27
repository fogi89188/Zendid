using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZendidServer.Data;

namespace ZendidServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly ILogger<ChatController> _logger;

        private readonly ApplicationDbContext _context;

        public ChatController(ILogger<ChatController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /*
        [HttpPost("chatroom")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse
            {
                Status = "fail"
            };

            await DeleteExpiredTokens();

            var user = _context.Users.FirstOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user != null)
            {
                response.Status = "success";
                response.Token = GenerateUserToken(user);
                await _context.SaveChangesAsync();
            }
            return response;
        }*/

    }
}
