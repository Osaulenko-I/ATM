using Contractions.AdminSessions.models;
using Contractions.UserSessions.Models;
using Core.Accounts;
using Core.Sessions.AdminSessions;

namespace Application.Mapping;

public static class CreatedAccountMappingExtensions
{
    public static CreatedAccountDto MapToDto(this AdminSession adminSession, Account account)
        => new CreatedAccountDto(account.MapToDto(), adminSession.MapToDto());
}