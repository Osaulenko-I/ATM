using Contractions.AdminSessions.Operations;

namespace Contractions.AdminSessions;

public interface IAdminSessionService
{
    CreateAccount.Response Create(CreateAccount.Request request);
    
    LoginAdminSession.Response Login(LoginAdminSession.Request request);
}