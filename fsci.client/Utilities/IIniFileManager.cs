namespace fsci.client.Utilities;

public interface IIniFileManager
{
    Dictionary<string, string> ReadResourceFile(string name);
    Dictionary<string, string> ReadFile(string path);
    void WriteFile(string path, Dictionary<string, string> content);
}