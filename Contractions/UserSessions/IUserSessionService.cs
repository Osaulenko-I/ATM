using Contractions.UserSessions.Operations;

namespace Contractions.UserSessions;

public interface IUserSessionService
{
    WithdrawAmount.Response Withdraw(WithdrawAmount.Request request);
    
    ReplenishAmount.Response Replenish(ReplenishAmount.Request request);
    
    ViewAmount.Response ViewBalance(ViewAmount.Request request);
    
    LoginAccount.Response Login(LoginAccount.Request request);
    
    ViewHistory.Response ViewHistory(ViewHistory.Request request);
}