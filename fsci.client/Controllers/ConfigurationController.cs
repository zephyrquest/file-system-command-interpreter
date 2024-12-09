using fsci.client.Models;
using fsci.client.Views;

namespace fsci.client.Controllers;

public class ConfigurationController
{
    private readonly IConfigurationView _configurationView;
    
    private readonly IConfigurationHandler _configurationHandler;
    
    
    public ConfigurationController(IConfigurationView configurationView, IConfigurationHandler configurationHandler)
    {
        _configurationView = configurationView;
        _configurationHandler = configurationHandler;
        
        _configurationHandler.InitConfigurations();
        var currentLanguage = _configurationHandler.GetConfiguration("language"); 
        LocalizationHandler.GetInstance().SwitchLanguage(currentLanguage);
        _configurationView.SetLanguage(currentLanguage);
        
        _configurationView.SetEventListener(SwitchLanguage);
    }

    private void SwitchLanguage(string language)
    {
        LocalizationHandler.GetInstance().SwitchLanguage(language);
        _configurationHandler.SetConfiguration("language", language);
    }
}