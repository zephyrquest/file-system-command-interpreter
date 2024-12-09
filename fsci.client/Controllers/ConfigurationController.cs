using fsci.client.Models;
using fsci.client.Observers;
using fsci.client.Views;

namespace fsci.client.Controllers;

public class ConfigurationController
{
    private readonly IConfigurationView _configurationView;
    
    private readonly IConfigurationHandler _configurationHandler;

    private readonly ILanguageChangeNotifier _languageChangeNotifier;
    
    
    public ConfigurationController(IConfigurationView configurationView, IConfigurationHandler configurationHandler,
        ILanguageChangeNotifier languageChangeNotifier)
    {
        _configurationView = configurationView;
        _configurationHandler = configurationHandler;
        _languageChangeNotifier = languageChangeNotifier;
        
        _configurationHandler.InitConfigurations();
        var currentLanguage = _configurationHandler.GetConfiguration("language"); 
        LocalizationHandler.GetInstance().SwitchLanguage(currentLanguage);
        _configurationView.SetLanguage(currentLanguage);
        _languageChangeNotifier.NotifyObservers();
        
        _configurationView.SetEventListener(SwitchLanguage);
    }

    private void SwitchLanguage(string language)
    {
        LocalizationHandler.GetInstance().SwitchLanguage(language);
        _languageChangeNotifier.NotifyObservers();
        _configurationHandler.SetConfiguration("language", language);
    }
}