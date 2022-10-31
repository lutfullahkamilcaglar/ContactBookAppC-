namespace MyProject;

public interface IUserManager
{
    void Login();

    void Register();

    void Logout();

    User GetUser();
    
    bool GetIsAuthenticated();
    
}