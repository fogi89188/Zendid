using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZendidServer.Data;
using ZendidServer.Data.Models;

namespace ZendidServer.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        protected readonly ApplicationDbContext _context;

        public BaseController(ILogger<BaseController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        protected async Task DeleteExpiredTokens()
        {
            var tokens = _context.Tokens.Where(x => x.ExpiresAt < DateTime.Now.AddHours(3));
            _context.Tokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
        }
        protected async Task<User> GetUserByToken(string token) {
            await DeleteExpiredTokens();
            var user = _context.Users.FirstOrDefault(x => x.Tokens.Any(y => y.TokenValue == token));
            return user;
        }  
    }
}
