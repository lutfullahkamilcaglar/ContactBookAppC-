using System.Net;
using MyProject.application;
using MyProject.infrastructure;

namespace MyProject;

internal static class Program
{
    
    private static readonly IInputManager InputManager = new InputManagerImpl();
    private static readonly Options Options = new (InputManager);
    private static readonly ListingOptions ListingOptions = new (InputManager, Options);
    internal static void Main(string[] args)
    {
        ListingOptions.StartListingOptions();
    }
}


