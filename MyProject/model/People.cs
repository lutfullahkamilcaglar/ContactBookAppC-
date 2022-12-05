using MyProject.res;
using Newtonsoft.Json;

namespace MyProject.model;

[Serializable]
public class People
{
    public readonly int Id;
    public readonly string Name;
    public readonly string Surname;
    public readonly string Email;
    public readonly DateTime DateOfBirth;
    public readonly int PhoneNumber;

    public int GetId()
    {
        return Id;
    }

    public DateTime GetBirthDate()
    {
        return DateOfBirth;
    }
    
    [JsonConstructor]
    public People(string name, string surname, string email, int phoneNumber, DateTime dateOfBirth, int id)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Id = id;
    }
    public People(string name, string surname, string email, int phoneNumber, DateTime dateOfBirth)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Id = GenerateId();
    }

    public void ListPersonInfo()
    {
        var info = string.Format(Resources.Contacts +
                                 (Resources.Id, Id) +
                                 (Resources.Name, Name) +
                                 (Resources.Surname, Surname) +
                                 (Resources.Email, Email) +
                                 (Resources.DateOfBirth, DateOfBirth) +
                                 (Resources.PhoneNumber, PhoneNumber));
        Console.WriteLine(info);
    }
    
    private static int GenerateId()
    {
        var random = new Random();
        return random.Next(1000 - 100) + 100;
    }


    public override bool Equals(object? obj)
    {
        if (obj is not People peopleDto)
        {
            return false;
        }
        
        return Id == peopleDto.Id;
    }
}