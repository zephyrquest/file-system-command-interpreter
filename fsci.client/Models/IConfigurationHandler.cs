namespace fsci.client.Models;

public interface IConfigurationHandler
{
    Dictionary<string, string> ReadUserConfigurationFile();
    void CreateUserConfigurationFile();
    void WriteUserConfigurationFile(Dictionary<string, string> content);
    bool UserConfigurationFileExists();
    void SetConfigurations();
    string GetConfiguration(string key);
}