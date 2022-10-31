using System;

namespace MyProject
{
    internal class InputManagerImpl : INputManager

    {

    public int GetInt()
    {
        int value = Convert.ToInt32(Console.ReadLine());
        return value;
    }

    public string GetString()
    {
        return Console.ReadLine()!;
    }

    public string GetStringWithDescription(string message = "")
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public int GetIntWithDescription(string message)
    {
        Console.WriteLine(message);
        return Convert.ToInt32(Console.ReadLine());
    }

    }
}