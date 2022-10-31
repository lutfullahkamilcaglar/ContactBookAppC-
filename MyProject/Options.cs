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
                ListAllContacts();
                break;
            case 2:
                CreateContact();
                break;
            case 3:
                DeleteContact();
                break;
            case 4:
                DisplayBirthDates();
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

    void ListAllContacts()
    {
        foreach (var people in peoples)
        {
            people.ListPersonInfo();
        }
    }

    void CreateContact()
    {
        var personName = _inputManager.GetStringWithDescription("Enter Name: ");
        var personSurname = _inputManager.GetStringWithDescription("Enter Surname: ");
        var email = _inputManager.GetStringWithDescription("Enter Email");
        var phoneNumber = _inputManager.GetIntWithDescription("Enter Phone number: ");
        var dateOfBirth = _inputManager.GetStringWithDescription("Enter Date of birth.");
        var newContact = new People(personName, personSurname, email, phoneNumber, dateOfBirth);
        peoples.Add(newContact);
        newContact.ListPersonInfo();
    }

    void DeleteContact()
    {
        var personId = _inputManager.GetIntWithDescription("Enter contact id to delete");
        foreach (var people in peoples)
        {
            if (personId == people.getId())
            {
                peoples.Remove(people);
            }
            Console.WriteLine($"Contact ID: {personId} has been deleted!");
        }
    }

    void DisplayBirthDates()
    {
        
    }
    
    
}



