using Core.Sessions.UserSessions;

namespace Abstractions.Persistence.Repositories;

public interface IUserSessionRepository
{
    void Add(UserSession session);
    
    UserSession? Query(Guid sessionId);
}