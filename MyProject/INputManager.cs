namespace MyProject;

public interface INputManager
{
    int GetInt();

    int GetIntWithDescription(string message);

    string GetString();

    string GetStringWithDescription(string message);

   // public DateTime Date { get; }

    public DateTime DateTime(string birthDate);






}