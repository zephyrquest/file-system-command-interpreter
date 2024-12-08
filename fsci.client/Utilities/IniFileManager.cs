using System.Reflection;

namespace fsci.client.Utilities;

public class IniFileManager : IIniFileManager
{
    private static IIniFileManager? _instance;


    private IniFileManager()
    {
        
    }

    public static IIniFileManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new IniFileManager();
        }
        
        return _instance;
    }
    
    public Dictionary<string, string> ReadResourceFile(string fileName)
    {
        var dictonary = new Dictionary<string, string>();
        
        var assembly = Assembly.GetExecutingAssembly();
        
        using (Stream? stream = assembly.GetManifestResourceStream($"fsci.client.Resources.{fileName}"))
        {
            if (stream == null)
                return new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(stream))
            {
                var fileContent = reader.ReadToEnd();
                
                var lines = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var line in lines)
                {
                    // Ignore comments and empty lines
                    if (line.StartsWith(";") || line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split(['='], 2);
                    if (parts.Length == 2)
                    {
                        dictonary.Add(parts[0], parts[1]);
                    }
                }

                return dictonary;
            }
        }
    }

    public Dictionary<string, string> ReadFile(string path)
    {
        var dictionary = new Dictionary<string, string>();

        if (!File.Exists(path))
            throw new FileNotFoundException($"The file at path {path} does not exist.");

        using (StreamReader reader = new StreamReader(path))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                // Ignore comments and empty lines
                if (line.StartsWith(";") || line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(['='], 2);
                if (parts.Length == 2)
                {
                    dictionary[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        return dictionary;
    }

    public void WriteFile(string path, Dictionary<string, string> content)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var kvp in content)
            {
                writer.WriteLine($"{kvp.Key}={kvp.Value}");
            }
        }
    }
}