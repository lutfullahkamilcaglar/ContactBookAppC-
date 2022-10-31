using System.Net;

namespace MyProject;

internal static class Kamil
{
    internal static void Exercise()
    {
        
    }
}
    
internal static class Program
{
    
    

    internal static void Main(string[] args)
    {
        INputManager inputManager = new InputManagerImpl();
        IUserManager authManager = new UserManagerImpl();
        Options options = new Options(inputManager, authManager);
        
        
        Controller controller = new Controller(inputManager,options,authManager);
        controller.StartApplication();
    }
}


