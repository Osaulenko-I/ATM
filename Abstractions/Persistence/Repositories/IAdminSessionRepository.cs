using Core.Sessions.AdminSessions;

namespace Abstractions.Persistence.Repositories;

public interface IAdminSessionRepository
{
    void Add(AdminSession adminSession);
    
    AdminSession? Query(Guid sessionId);
}