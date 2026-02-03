using Contractions.AdminSessions.models;
using Core.Sessions.AdminSessions;

namespace Application.Mapping;

public static class AdminSessionMappingExtensions
{
    public static AdminSessionDto MapToDto(this AdminSession adminSession)
        => new AdminSessionDto(adminSession.SessionId);
}