using fsci.client.Commands;
using fsci.client.Controllers;
using fsci.client.Models;
using fsci.client.Observers;

namespace fsci.client;

public partial class MainPage : ContentPage
{
    private readonly IConfigurationHandler _configurationHandler = new ConfigurationHandler();
    
    private readonly IOutputHandler _outputHandler = new OutputHandler();
    private readonly IFileSystemHandler _fileSystemHandler = new FileSystemHandler();
    
    private readonly CommandManager _commandManager;
    
    private readonly CommandController _commandController;
    private readonly ConfigurationController _configurationController;

    private readonly ILanguageChangeNotifier _languageChangeNotifier = new LanguageChangeNotifier();
    
    
    public MainPage()
    {
        InitializeComponent();
        
        _commandManager = new CommandManager(_fileSystemHandler, _outputHandler);

        _languageChangeNotifier.AddObserver(ConfigurationView);
        _languageChangeNotifier.AddObserver(CommandInputView);
        
        _configurationController = new ConfigurationController(ConfigurationView, _configurationHandler, _languageChangeNotifier);
        _commandController = new CommandController(CommandInputView, OutputAreaView,
            _outputHandler,
            _commandManager);
    }
}