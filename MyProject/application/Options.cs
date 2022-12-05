using MyProject.infrastructure;
using MyProject.model;
using MyProject.res;
using System.Net.Mail;
namespace MyProject.application;

public class Options
{
    private readonly IInputManager _inputManager;

    private static List<People> PeopleList => FileManager.ReadPeopleFile();
    public Options(IInputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public static void ListAllContacts()
    {
        foreach (var people in PeopleList)
        {
            people.ListPersonInfo();
        }
    }

    public void SearchContact()
    {
        var searchId = _inputManager.GetIntWithDescription(Resources.EnterContactId);
        var searchContact = PeopleList.FirstOrDefault(people => searchId == people.GetId());

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
         var email = _inputManager.GetValidEmailAddress(Resources.EnterEmail);
         var phoneNumber = _inputManager.GetPhoneNumberWithDescription(Resources.EnterPhoneNumber);
         var dateOfBirth = _inputManager.DateTime(Resources.EnterDateOfBirth);
         var newContact = new People(personName, personSurname, email, phoneNumber, dateOfBirth);
         FileManager.SavePeopleToFile(newContact);
         newContact.ListPersonInfo();
    }

    public void DeleteContact()
    {
        var personId = _inputManager.GetIntWithDescription(Resources.DeleteId);
        var deleteContact = PeopleList.FirstOrDefault(people => personId == people.GetId());


        if (deleteContact == null)
        {
            Console.WriteLine(Resources.NoMatchIdError);
        }
        else
        {
            FileManager.RemovePeopleFromFile(deleteContact);
            Console.WriteLine(Resources.ContactDelete, personId);
        }
    }

    public void EditContact()
    {
        var editId = _inputManager.GetIntWithDescription(Resources.EnterContactId);

        var contact = PeopleList.FirstOrDefault(people => editId == people.GetId());

        if (contact != null)
        {
            FileManager.RemovePeopleFromFile(contact);
            Console.WriteLine(Resources.EnterContactInformation);
            CreateContact();
            Console.WriteLine(Resources.ContactHasBeenUpdated);
        }
        else
        {
            Console.WriteLine(Resources.NoMatchIdError);
        }
    }

    public static void DisplayBirthDates()
    {
        var contacts = PeopleList.Where(CheckBirthDate);

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