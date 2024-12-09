namespace fsci.client.Views;

public interface IConfigurationView
{
    void SetLanguage(string languageCode);
    void SetEventListener(Action<string> languageSelected);
}