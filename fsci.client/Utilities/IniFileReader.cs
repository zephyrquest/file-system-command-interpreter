using System.Reflection;

namespace fsci.client.Utilities;

public class IniFileReader
{
    private readonly string _baseNamespace = "fsci.client.Resources";

    
    public Dictionary<string, string> ReadFile(string fileName)
    {
        var dictonary = new Dictionary<string, string>();
        
        var assembly = Assembly.GetExecutingAssembly();
        
        using (Stream? stream = assembly.GetManifestResourceStream($"{_baseNamespace}.{fileName}"))
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
}