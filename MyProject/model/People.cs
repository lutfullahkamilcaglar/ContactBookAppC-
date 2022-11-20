using MyProject.res;

namespace MyProject.model;

public class People
{
    private readonly int _id;
    private readonly string _name;
    private readonly string _surname;
    private readonly string _email;
    private readonly DateTime _dateOfBirth;
    private readonly int _phoneNumber;

    public int GetId()
    {
        return _id;
    }

    public DateTime GetBirthDate()
    {
        return _dateOfBirth;
    }
    public People(string name, string surname, string email, int phoneNumber, DateTime dateOfBirth)
    {
        _name = name;
        _surname = surname;
        _email = email;
        _phoneNumber = phoneNumber;
        _dateOfBirth = dateOfBirth;
        _id = GenerateId();
    }

    public void ListPersonInfo()
    {
        var info = string.Format(Resources.Contacts +
                                 (Resources.Id, _id) +
                                 (Resources.Name, _name) +
                                 (Resources.Surname, _surname) +
                                 (Resources.Email, _email) +
                                 (Resources.DateOfBirth, _dateOfBirth) +
                                 (Resources.PhoneNumber, _phoneNumber));
        Console.WriteLine(info);
    }

    
    private static int GenerateId()
    {
        var random = new Random();
        return random.Next(1000 - 100) + 100;
    }
}