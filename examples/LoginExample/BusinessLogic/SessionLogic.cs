using Domain;

namespace BusinessLogic;

public class SessionLogic
{
    private readonly UserLogic _userLogic;
    public User CurrentUser { get; set; }
    
    public SessionLogic(UserLogic userLogic)
    {
        _userLogic = userLogic;
    }
    
    public void Login(User anyUser)
    {
        User? user = _userLogic.Login(anyUser);
        CurrentUser = user;
    }

    public void Logout()
    {
        CurrentUser = null;
    }

    public bool IsLoggedIn()
    {
        return CurrentUser != null;
    }
}