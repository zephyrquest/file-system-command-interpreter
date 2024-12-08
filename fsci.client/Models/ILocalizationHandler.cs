namespace fsci.client.Models;

public interface ILocalizationHandler
{
    void SetUpResourceManager();
    void SwitchLanguage(string language);
    string GetValue(string key);
}