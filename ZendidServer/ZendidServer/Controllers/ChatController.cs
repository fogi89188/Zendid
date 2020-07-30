using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZendidCommons;
using ZendidServer.Data;
using ZendidServer.Data.Models;

namespace ZendidServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : BaseController
    {
        public ChatController(ILogger<AccountController> logger, ApplicationDbContext context)
            : base(logger, context)
        { }


        [HttpPost("update")]
        public async Task<ChatUpdateResponse> ChatUpdate(ChatUpdateRequest request)
        {
            ChatUpdateResponse response = new ChatUpdateResponse
            {
                Status = "fail",
                ErrorCode = ZendidErrorCodes.OK
            };
            var user = await GetUserByToken(request.Token);
            if (user == null)
            {
                response.ErrorCode = ZendidErrorCodes.TokenExpired;
                return response;
            }

            await DeleteExpiredTokens();

            response.TimeOfLastUpdate = DateTime.Now;
            List<string> users = _context.Users.Where(x => x.Tokens.Any()).Select(x => x.UserName).OrderBy(x => x).ToList();
            var messages = _context.Messages.Where(x => x.SendTime > request.TimeOfLastUpdate).Select(x => new ZendidCommons.Message
            {
                MessageStr = x.MessageStr,
                UserSender = x.UserName,
                Time = x.SendTime
            }).ToList();

            response.Status = "success";
            response.Messages = messages;
            response.Users = users;

            return response;
        }


        [HttpPost("sendMessage")]
        public async Task<MessageSendResponse> SendMessage(MessageSendRequest request)
        {
            MessageSendResponse response = new MessageSendResponse
            {
                Status = "fail",
                ErrorCode = ZendidErrorCodes.OK
            };
            var user = await GetUserByToken(request.Token);
            if (user == null)
            {
                response.ErrorCode = ZendidErrorCodes.TokenExpired;
                return response;
            }

            await DeleteExpiredTokens();

            _context.Messages.Add(new Data.Models.Message
            {
                UserName = user.UserName,
                MessageStr = request.MessageStr,
                SendTime = DateTime.Now
            });
            await _context.SaveChangesAsync();

            response.TimeOfLastUpdate = DateTime.Now;

            List<string> users = _context.Users.Where(x => x.Tokens.Any()).Select(x => x.UserName).OrderBy(x => x).ToList();
            var messages = _context.Messages.Where(x => x.SendTime > request.TimeOfLastUpdate).Select(x => new ZendidCommons.Message
            {
                MessageStr = x.MessageStr,
                UserSender = x.UserName,
                Time = x.SendTime
            }).ToList();

            response.Status = "success";
            response.Messages = messages;
            response.Users = users;

            return response;
        }
    }
}
