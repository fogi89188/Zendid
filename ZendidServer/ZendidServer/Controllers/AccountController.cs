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
    public class AccountController : BaseController
    {
        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context)
            : base(logger, context)
        { }

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
                response.ServerTime = DateTime.Now;
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
                response.TimeOfLastUpdate = DateTime.Now;

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
                ExpiresAt = DateTime.Now.AddSeconds(30)
            });
            return token;
        }

    }
}
