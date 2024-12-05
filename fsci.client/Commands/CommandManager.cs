using System.Reflection;
using fsci.client.Utilities;

namespace fsci.client.Commands;

public class CommandManager
{
    private readonly string _fileName = "available_commands.ini";
    private readonly IniFileReader _iniFileReader = new();
    private readonly Dictionary<string, string> _availableCommands;
    
    
    public CommandManager()
    {
        _availableCommands = _iniFileReader.ReadFile(_fileName);
    }

    public bool IsCommandValid(string acronym)
    {
        return _availableCommands.ContainsKey(acronym);
    }

    public Command CreateCommand(string acronym)
    {
        if (string.IsNullOrWhiteSpace(acronym))
        {
            throw new ArgumentException("Acronym cannot be null or empty.", nameof(acronym));
        }

        if (!_availableCommands.ContainsKey(acronym))
        {
            throw new KeyNotFoundException($"Command for acronym '{acronym}' was not found.");
        }

        try
        {
            var commandClass = _availableCommands[acronym];
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(commandClass);

            if (type == null)
            {
                throw new TypeLoadException($"Type '{commandClass}' could not be found in the assembly.");
            }

            var instance = Activator.CreateInstance(type, acronym);

            if (instance is not Command commandInstance)
            {
                throw new InvalidOperationException($"The type '{commandClass}' is not a valid Command.");
            }

            return commandInstance;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(@$"Error occurred during command creation 
                for acronym '{acronym}': {ex.Message}", ex);
        }
    }
}