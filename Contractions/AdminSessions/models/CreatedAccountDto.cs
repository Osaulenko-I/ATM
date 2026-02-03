using Contractions.UserSessions.Models;

namespace Contractions.AdminSessions.models;

public sealed record CreatedAccountDto(AccountDto Account, AdminSessionDto AdminSession);