using fsci.client.Utilities;

namespace fsci.client.Models;

public class ConfigurationHandler : IConfigurationHandler
{
    private readonly string _userHomeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private readonly string _userConfigurationDirectoryName = ".file_system_command_interpreter";
    private readonly string _userConfigurationDirectoryFullPath;
    private readonly string _userConfigurationFileName = "fsci.ini";
    private readonly string _userConfigurationFileFullPath;
    
    private Dictionary<string, string>? _configurations;

    
    public ConfigurationHandler()
    {
        _userConfigurationDirectoryFullPath = Path.Combine(_userHomeDirectory, _userConfigurationDirectoryName);
        _userConfigurationFileFullPath = Path.Combine(_userConfigurationDirectoryFullPath, _userConfigurationFileName);
    }
    
    public Dictionary<string, string> ReadUserConfigurationFile()
    {
        return IniFileManager.GetInstance().ReadFile(_userConfigurationFileFullPath);
    }

    public void CreateUserConfigurationFile()
    {
        var data = IniFileManager.GetInstance().ReadResourceFile("default_user_config.ini");
        
        Directory.CreateDirectory(_userConfigurationDirectoryFullPath);
        
        WriteUserConfigurationFile(data);
    }

    public void WriteUserConfigurationFile(Dictionary<string, string> content)
    {
        IniFileManager.GetInstance().WriteFile(_userConfigurationFileFullPath, content);
    }

    public bool UserConfigurationFileExists()
    {
        return File.Exists(_userConfigurationFileFullPath);
    }

    public void InitConfigurations()
    {
        if (!UserConfigurationFileExists())
        {
            CreateUserConfigurationFile();
        }

        _configurations = ReadUserConfigurationFile();
    }

    public string GetConfiguration(string key)
    {
        if (_configurations == null)
        {
            throw new InvalidOperationException("The configurations have not been initialized.");
        }
        
        var value = _configurations[key];
        
        if (value == null)
        {
            throw new KeyNotFoundException($"The resource key '{key}' was not found."); 
        }

        return value;
    }

    public void SetConfiguration(string key, string value)
    {
        if (_configurations == null)
        {
            throw new InvalidOperationException("The configurations have not been initialized.");
        }

        if (!_configurations.Keys.Contains(key))
        {
            throw new KeyNotFoundException($"The resource key '{key}' was not found."); 
        }
        
        _configurations[key] = value;
        
        WriteUserConfigurationFile(_configurations);
    }
}