using MyProject.infrastructure;
using MyProject.res;

namespace MyProject.application;

public class ListingOptions
{
    private readonly IInputManager _inputManager;
    private readonly Options _options;

    public ListingOptions(IInputManager inputManager, Options options)
    {
        _inputManager = inputManager;
        _options = options;
    }

    public void StartListingOptions()
    {
        while (true)
        {
            var shouldExit = ListOptions();
            if (shouldExit)
            {
                break;
            }
        }
    }

    private bool ListOptions()
    {
        var selection = _inputManager.GetIntWithDescription(Resources.OptionListing);
        var exitSelection = false;

        switch (selection)
        {
            case 1:
                Options.ListAllContacts();
                break;
            case 2:
                _options.CreateContact();
                break;
            case 3:
                _options.DeleteContact();
                break;
            case 4:
                Options.DisplayBirthDates();
                break;
            case 5:
                _options.EditContact();
                break;
            case 6:
                _options.SearchContact();
                break;
            case 7:
                
                break;
            case 8:
                Options.ExitSelection(out exitSelection);
                break;
            default:
                Options.DefaultFunction();
                break;
        }

        return exitSelection;
    }
}