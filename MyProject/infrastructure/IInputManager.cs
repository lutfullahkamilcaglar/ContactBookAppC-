namespace MyProject.infrastructure;
using System.Net.Mail;
public interface IInputManager
{
    int GetInt();

    int GetIntWithDescription(string message);

    int GetPhoneNumberWithDescription(string message);
    string GetString();

    string GetStringWithDescription(string message);

    string GetValidEmailAddress(string message);

    public DateTime DateTime(string birthDate);

}