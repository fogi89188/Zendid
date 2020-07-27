using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZendidCommons;
using ZendidServer.Data;
using ZendidServer.Data.Models;

namespace ZendidServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        private readonly ApplicationDbContext _context;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("login")]
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
        }


        [HttpPost("register")]
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            RegisterResponse response = new RegisterResponse
            {
                Status = "fail",
                ErrorCode = ZendidErrorCodes.OK
            };

            if (!_context.Users.Any(x => x.UserName.Contains(request.UserName)))
            {
                var user = new User
                {
                    UserName = request.UserName,
                    Password = request.Password,
                };
                response.Status = "success";
                response.Token = GenerateUserToken(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                response.ErrorCode = ZendidErrorCodes.UserAlreadyExists;
            }
            return response;
        }

        private string GenerateUserToken(User user)
        {
            var token = Guid.NewGuid().ToString();
            _context.Tokens.Add(new Token
            {
                TokenValue = token,
                User = user,
                ExpiresAt = DateTime.Now.AddMinutes(30)
            });
            return token;
        }

        private async Task DeleteExpiredTokens()
        {
            var tokens = _context.Tokens.Where(x => x.ExpiresAt < DateTime.Now.AddHours(3));
            _context.Tokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
        }
    }
}
