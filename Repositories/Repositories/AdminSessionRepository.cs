using Abstractions.Persistence.Repositories;
using Core.Sessions.AdminSessions;

namespace Repositories.Repositories;

public sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid,AdminSession> _values = [];
    
    public void Add(AdminSession adminSession)
    {
        _values.Add(adminSession.SessionId, adminSession);
    }

    public AdminSession? Query(Guid sessionId)
    {
        return _values.ContainsKey(sessionId) ? _values[sessionId] : null;
    }
}