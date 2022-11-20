using MyProject.infrastructure;
using MyProject.model;
using MyProject.res;

namespace MyProject.application;

public class Options
{
    private readonly IInputManager _inputManager;
    private readonly List<People> _peopleList = new();

    public Options(IInputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public void ListAllContacts()
    {
        foreach (var people in _peopleList)
        {
            people.ListPersonInfo();
        }
    }

    public void SearchContact()
    {
        var searchId = _inputManager.GetIntWithDescription(Resources.EnterContactId);
        var searchContact = _peopleList.FirstOrDefault(people => searchId == people.GetId());

        if (searchContact != null)
        {
            searchContact.ListPersonInfo();
        }
        else
        {
            Console.WriteLine(Resources.NoMatchIdError);
        }
    }

    public void CreateContact()
    {
        var personName = _inputManager.GetStringWithDescription(Resources.EnterName);
        var personSurname = _inputManager.GetStringWithDescription(Resources.EnterSurname);
        var email = _inputManager.GetStringWithDescription(Resources.EnterEmail);
        var phoneNumber = _inputManager.GetIntWithDescription(Resources.EnterPhoneNumber);
        var dateOfBirth = _inputManager.DateTime(Resources.EnterDateOfBirth);
        
        var newContact = new People(personName, personSurname, email, phoneNumber, dateOfBirth);
        _peopleList.Add(newContact);
        newContact.ListPersonInfo();
    }

    public void DeleteContact()
    {
        var personId = _inputManager.GetIntWithDescription(Resources.DeleteId);
        List<People> deleteList = new();

        
        foreach (var people in _peopleList)
        {
            if (personId == people.GetId())
            {
                deleteList.Add(people);
            }
            else
            {
                Console.WriteLine(Resources.NoMatchIdError);
            }
        }

        foreach (var people in deleteList)
        {
            _peopleList.Remove(people);
            Console.WriteLine(Resources.ContactDelete, personId);
        }
    }

    public void EditContact()
    {
        var editId = _inputManager.GetIntWithDescription(Resources.EnterContactId);

        var contact = _peopleList.FirstOrDefault(people => editId == people.GetId());

        if (contact != null)
        {
            _peopleList.Remove(contact);
            Console.WriteLine(Resources.EnterContactInformation);
            CreateContact();
            Console.WriteLine(Resources.ContactHasBeenUpdated);
        }
        else
        {
            Console.WriteLine(Resources.NoMatchIdError);
        }
    }

    public void DisplayBirthDates()
    {
        var contacts = _peopleList.Where(CheckBirthDate);

        foreach (var contact in contacts)
        {
            contact.ListPersonInfo();
        }
    }

    private static bool CheckBirthDate(People people)
    {
        var start = DateTime.Now;
        var end = start + TimeSpan.FromDays(7);

        var birthDate = people.GetBirthDate();
        var compareDate = birthDate.AddYears(start.Year - birthDate.Year);

        return (start < compareDate || compareDate.DayOfYear == start.DayOfYear ) && compareDate < end;
    }

    public static void ExitSelection(out bool selection)
    {
        selection = true;
        Console.WriteLine(Resources.SystemExit);
    }

    public static void DefaultFunction()
    {
        Console.WriteLine(Resources.NoSuchOption);
    }
}