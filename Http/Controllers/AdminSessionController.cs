using System;
using Contractions.AdminSessions;
using Contractions.AdminSessions.models;
using Contractions.AdminSessions.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Http.Controllers;

[ApiController]
[Route("api/admin/session")]
public sealed class AdminSessionController : ControllerBase
{
    private readonly IAdminSessionService _adminSessionService;

    public AdminSessionController(IAdminSessionService adminSessionService)
    {
        _adminSessionService = adminSessionService;
    }

    [HttpPost("create")]
    public ActionResult<CreatedAccountDto> CreateSession(decimal amount, string pin, Guid adminSessionId)
    {
        var request = new CreateAccount.Request(adminSessionId, pin, amount);
        
        var response = _adminSessionService.Create(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.AdminSessionDto),
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => BadRequest()
        };
    }

    [HttpPost("login")]
    public ActionResult<AdminSessionDto> Login(string password)
    {
        var request = new LoginAdminSession.Request(password);
        
        var response = _adminSessionService.Login(request);

        return response switch
        {
            LoginAdminSession.Response.Success success => Ok(success.AdminSessionDto),
            LoginAdminSession.Response.Failure failure => NotFound(failure.Message),
            _ => BadRequest()
        };
    }
}