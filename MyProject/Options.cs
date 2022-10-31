namespace MyProject;

public class Options
{
    private readonly INputManager _inputManager;

    private readonly IUserManager _userManager;
    
    private readonly List<People> peoples = new();

    public Options(INputManager inputManager, IUserManager userManager)
    {
        _inputManager = inputManager;
        _userManager = userManager;
    }

    public void StartListingOptions()
    {
        while (true)
        {
            var isLogOut = ListOptions();
            if (isLogOut)
            {
                break;
            }
        }
    }

    private bool ListOptions()
    { 
        int selection = _inputManager.GetIntWithDescription(Resources.OptionListing);
        bool isLoggedOut = false;

        switch (selection)
        {
            case 1:
                Console.WriteLine("Method1");
                break;
            case 2:
                Console.WriteLine("Method2");
                break;
            case 3:
                Console.WriteLine("Method3");
                break;
            case 4:
                Console.WriteLine("Method4");
                break;
            case 5:
                isLoggedOut = true;
                Console.WriteLine("Logged Out");
                break;
            default:
                Console.WriteLine("There is no such option.");
                break;
        }
        return isLoggedOut;
    }
    
    
    
}



