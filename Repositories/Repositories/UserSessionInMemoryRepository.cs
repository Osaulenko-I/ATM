using Abstractions.Persistence.Repositories;
using Core.Sessions.UserSessions;

namespace Repositories.Repositories;

public class UserSessionInMemoryRepository : IUserSessionRepository
{
    private readonly Dictionary<Guid, UserSession> _values = [];
    
    public void Add(UserSession session)
    {
        _values.Add(session.SessionId, session);
    }

    public UserSession? Query(Guid sessionId)
    {
        return _values.ContainsKey(sessionId) ? _values[sessionId] : null;
    }
}