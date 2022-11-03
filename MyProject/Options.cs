namespace MyProject;

public class Options
{
    private readonly INputManager _inputManager;

    private readonly IUserManager _userManager;

    private readonly List<People> _peopleList = new();

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
        foreach (var people in _peopleList)
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
        var dateOfBirth = _inputManager.DateTime("Enter Date of birth. With this format dd/mm/yyyy");
        var newContact = new People(personName, personSurname, email, phoneNumber, dateOfBirth);
        _peopleList.Add(newContact);
        newContact.ListPersonInfo();
    }

    void DeleteContact()
    {
        var personId = _inputManager.GetIntWithDescription("Enter contact id to delete");
        List<People> deleteList = new();

        foreach (var people in _peopleList)
        {
            if (personId == people.GetId())
            {
                deleteList.Add(people);
                // _peopleList.Remove(people);
                // Console.WriteLine($"Contact ID: {personId} has been deleted!");
                // break;
            }
        }

        foreach (var people in deleteList)
        {
            _peopleList.Remove(people);
            Console.WriteLine($"Contact ID: {personId} has been deleted!");
        }
    }

    void DisplayBirthDates()
    {

        var annen = _inputManager.DateTime("Date of birth type");
        
        Console.WriteLine(annen);

        // DateTime birthDay = DateTime.Now;
        // var today = DateTime.Today;
        //
        // bool IsBirthWeek(DateTime payDate, DateTime birthDate)
        // {
        //     DateTime dtStart = payDate.AddDays(-6);
        //     DateTime dtEnd = payDate;
        //     int dayStart = dtStart.DayOfYear;
        //     int dayEnd = dtEnd.DayOfYear;
        //     int birthDayY = birthDate.DayOfYear;
        //     return (birthDayY >= dayStart && birthDayY < dayEnd);
        // }
        // Console.WriteLine(IsBirthWeek(today, birthDay));
    }
}



