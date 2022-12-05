using MyProject.model;
using Newtonsoft.Json;

namespace MyProject.infrastructure;

public static class FileManager
{
    private const string FilePath = @"/Users/kamilcaglar/Desktop/C# Project /MyProject/MyProject/ContactData.txt";

    public static void SavePeopleToFile(People people)
    {
        var jsonText = File.ReadAllText(FilePath);
        var peopleList = JsonConvert.DeserializeObject<List<People>>(jsonText) ?? new List<People>();
        peopleList.Add(people);
        var jsonResult = JsonConvert.SerializeObject(peopleList);
        File.WriteAllText(FilePath, jsonResult);
    }
    
    public static List<People> ReadPeopleFile()
    {
        var jsonText = File.ReadAllText(FilePath);
        var peopleList = JsonConvert.DeserializeObject<List<People>>(jsonText) ?? new List<People>();
        return peopleList;
    }

    
    public static void RemovePeopleFromFile(People people)
    {
        var jsonText = File.ReadAllText(FilePath);
        var peopleList = JsonConvert.DeserializeObject<List<People>>(jsonText) ?? new List<People>();
        peopleList.Remove(people);
        var jsonResult = JsonConvert.SerializeObject(peopleList);
        File.WriteAllText(FilePath, jsonResult);
    }
}