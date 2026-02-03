using System;
using Contractions.UserSessions;
using Contractions.UserSessions.Models;
using Contractions.UserSessions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Http.Controllers;

[ApiController]
[Route("api/user/session")]
public sealed class UserSessionController : ControllerBase
{
    private readonly IUserSessionService _userSessionService;
    
    public UserSessionController(IUserSessionService userSessionService)
    {
        _userSessionService = userSessionService;
    }

    [HttpPost("login")]
    public ActionResult<UserSessionDto> Login(long accountId, string pin)
    {
        var request = new LoginAccount.Request(accountId, pin);
        
        var response = _userSessionService.Login(request);

        return response switch
        {
            LoginAccount.Response.Success success => Ok(success.UserSessionDto),
            LoginAccount.Response.Failure failure => BadRequest(failure.Massage),
            _ => BadRequest()
        };
    }

    [HttpPost("Withdraw")]
    public ActionResult<UserSessionDto> Withdraw(Guid userSessionId, decimal amount)
    {
        var request = new WithdrawAmount.Request(userSessionId, amount);
        
        var response = _userSessionService.Withdraw(request);

        return response switch
        {
            WithdrawAmount.Response.Success success => Ok(success.UserSessionDto),
            WithdrawAmount.Response.Failure failure => BadRequest(failure.Message),
            _ => BadRequest()
        };
    }
    
    [HttpPost("Replenish")]
    public ActionResult<UserSessionDto> Replenish(Guid userSessionId, decimal amount)
    {
        var request = new ReplenishAmount.Request(userSessionId, amount);
        
        var response = _userSessionService.Replenish(request);

        return response switch
        {
            ReplenishAmount.Response.Success success => Ok(success.UserSessionDto),
            ReplenishAmount.Response.Failure failure => BadRequest(failure.Message),
            _ => BadRequest()
        };
    }
    
    [HttpPost("ViewBalance")]
    public ActionResult<decimal> ViewBalance(Guid userSessionId)
    {
        var request = new ViewAmount.Request(userSessionId);
        
        var response = _userSessionService.ViewBalance(request);
    
        return response switch
        {
            ViewAmount.Response.Success success => Ok(success.UserSessionDto.Account.Balance),
            ViewAmount.Response.Failure failure => BadRequest(failure.Message),
            _ => BadRequest()
        };
    }

    [HttpPost("viewHistory")]
    public ActionResult<HistoryDto> History(Guid userSessionId)
    {
        var request = new ViewHistory.Request(userSessionId);
        
        var response = _userSessionService.ViewHistory(request);

        return response switch
        {
            ViewHistory.Response.Success success => Ok(success.HistoryDto),
            ViewHistory.Response.Failure failure => BadRequest(failure.Message),
            _ => BadRequest()
        };
    }
}