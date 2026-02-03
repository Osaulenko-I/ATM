using Contractions.UserSessions.Models;
using Core.Sessions.UserSessions;

namespace Application.Mapping;

public static class UserSessionMappingExtensions
{
    public static UserSessionDto MapToDto(this UserSession userSession)
        => new UserSessionDto(userSession.SessionId, userSession.Account.MapToDto());
}