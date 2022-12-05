namespace MyProject.res;

public static class Resources
{

    // listOptions
    public const string OptionListing = "Welcome. Please make a chose." +
                                  "\nYour options:" +
                                  "\n1.List all contacts." +
                                  "\n2.Create new contact." +
                                  "\n3.Delete contact" +
                                  "\n4.Display birthdays in current week." +
                                  "\n5.Edit contact" +
                                  "\n6.Search contact" +
                                  "\n7.Save" +
                                  "\n8.Exit ";

    public const string Contacts = "Contacts: ";
    public const string Id = "Id: ";
    public const string Name = "Name: ";
    public const string Surname = "Surname: ";
    public const string Email = "Email: ";
    public const string DateOfBirth = "Date of birth: ";
    public const string PhoneNumber = "Phone Number: ";
    
    // Options

    
    public const string SystemExit = "System Exit!";
    public const string EnterContactInformation = "Enter contact information.";
    public const string ContactHasBeenUpdated = "Contact has been updated.";
    public const string EnterContactId = "Please enter contact ID: ";
    public const string NoSuchOption = "There is no such option.";
    public const string EnterName = "Enter Name: ";
    public const string EnterSurname = "Enter Surname: ";
    public const string EnterEmail = "Enter Email";
    public const string EnterPhoneNumber = "Enter Phone number(only numbers will be validated.): ";
    public const string EnterDateOfBirth = "Enter Date of birth. With this format dd/mm/yyyy";
    
    
    //methods

    public const string ContactDelete = "Contact ID: {0} has been deleted!";
    public const string DeleteId = "Enter contact id to delete";
    public const string NoMatchIdError = "There is no match for this id.";
}