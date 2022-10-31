namespace MyProject;
public class Controller
{
    //private InputManager inputManager;

    private readonly IUserManager _authManager;
    private readonly INputManager _inputManager;
    private readonly Options _options;

    public Controller(INputManager inputManager, Options options, IUserManager authManager)
    {
        _authManager = authManager;
        _inputManager = inputManager;
        _options = options;
    }
    
    public void StartApplication()
    {
        while (true)
        {
            Boolean isExit = LoginSection();
            if (isExit)
            {
                break;
            }

            if (_authManager.GetIsAuthenticated())
            {
                _options.StartListingOptions();
                _authManager.Logout();
            }
        }
    }

    private bool LoginSection()
    {
        var selection = _inputManager.GetIntWithDescription(Resources.LoginListing);

        switch (selection)
        {
            case 1:
                _authManager.Login();
                break;
            case 2:
                _authManager.Register();
                break;
            case 0:
                return true;
        }
        return false;
    }
    
}