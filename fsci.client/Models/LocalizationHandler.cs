using System.Globalization;
using System.Resources;

namespace fsci.client.Models;

public class LocalizationHandler : ILocalizationHandler
{
    private static LocalizationHandler? _localizationHandler;
    
    private readonly string _baseNamespace = "fsci.client.Resources.TranslatedText.Text";

    private ResourceManager? _resourceManager;


    private LocalizationHandler()
    {
        
    }

    public static LocalizationHandler GetInstance()
    {
        if (_localizationHandler == null)
        {
            _localizationHandler = new LocalizationHandler();
            _localizationHandler.SetUpResourceManager();
        }

        return _localizationHandler;
    }

    public void SetUpResourceManager()
    {
        _resourceManager = new ResourceManager(_baseNamespace, typeof(LocalizationHandler).Assembly);
        SwitchLanguage("en");
    }

    public void SwitchLanguage(string language)
    {
        try
        {
            var culture = new CultureInfo(language);
            // For resource lookup
            CultureInfo.CurrentUICulture = culture;
            // For number, date, etc., formatting
            CultureInfo.CurrentCulture = culture;
        }
        catch (CultureNotFoundException)
        {
            throw new ArgumentException($"The specified language '{language}' is not a valid culture.", nameof(language));
        }
    }

    public string GetValue(string key)
    {
        if (_resourceManager == null)
        {
            throw new InvalidOperationException("ResourceManager is not initialized.");
        }
        
        var value = _resourceManager.GetString(key);

        if (value == null)
        {
            throw new KeyNotFoundException($"The resource key '{key}' was not found."); 
        }

        return value;
    }
}