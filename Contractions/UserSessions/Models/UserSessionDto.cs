namespace Contractions.UserSessions.Models;

public sealed record UserSessionDto(Guid SessionId, AccountDto Account);