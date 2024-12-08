using fsci.client.Commands;
using fsci.client.Controllers;
using fsci.client.Models;

namespace fsci.client;

public partial class MainPage : ContentPage
{
    private readonly IConfigurationHandler _configurationHandler = new ConfigurationHandler();
    
    private readonly IOutputHandler _outputHandler = new OutputHandler();
    private readonly IFileSystemHandler _fileSystemHandler = new FileSystemHandler();
    
    private readonly CommandManager _commandManager;
    
    private readonly CommandController _commandController;
    
    
    public MainPage()
    {
        InitializeComponent();
        
        _configurationHandler.SetConfigurations();
        LocalizationHandler.GetInstance().SwitchLanguage(_configurationHandler.GetConfiguration("language"));

        _commandManager = new CommandManager(_fileSystemHandler, _outputHandler);

        _commandController = new CommandController(CommandInputView, OutputAreaView, 
            _outputHandler, 
            _commandManager);
    }
}