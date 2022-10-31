namespace MyProject;

public class People
{
    private readonly int id;
    private readonly string name;
    private readonly string surname;
    private readonly string email;
    private readonly string dateOfBirth;
    private readonly int phoneNumber;

    public int getId()
    {
        return id;
    }

    public People(string name, string surname, string email, int phoneNumber, string dateOfBirth)
    {
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.phoneNumber = phoneNumber;
        id = GenerateId();
    }

    public void ListPersonInfo()
    {
        string info = string.Format("Contacts:" +
                                    ("Id:",id) +
                                    ("Name: ",name) +
                                    ("Surname: ",surname) +
                                    ("Email: ",email) +
                                    ("Phone Number: ",phoneNumber));
        Console.WriteLine(info);
    }


    public int GenerateId()
    {
        Random random = new Random();
        return random.Next(1000 - 100) + 100;
    }
}