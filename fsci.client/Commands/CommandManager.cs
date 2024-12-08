using System.Reflection;
using fsci.client.Models;
using fsci.client.Utilities;

namespace fsci.client.Commands;

public class CommandManager
{
    public static Dictionary<string, string> AvailableCommands = new();
    
    private readonly string _fileName = "available_commands.ini";

    private readonly IFileSystemHandler _fileSystemHandler;
    private readonly IOutputHandler _outputHandler;
    
    
    public CommandManager(IFileSystemHandler fileSystemHandler, IOutputHandler outputHandler)
    {
        _fileSystemHandler = fileSystemHandler;
        _outputHandler = outputHandler;
        
        AvailableCommands = IniFileManager.GetInstance().ReadResourceFile(_fileName);
    }

    public Command? CreateCommand(string acronym, string[] parameters)
    {
        if (string.IsNullOrWhiteSpace(acronym))
        {
            throw new ArgumentException("Acronym cannot be null or empty.", nameof(acronym));
        }

        if (!IsCommandAcronymValid(acronym))
        {
            _outputHandler.AddCommandNotFoundMessage(acronym);
            return null;
        }

        try
        {
            var commandClass = AvailableCommands[acronym];
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

            if (commandInstance is IParameterCommand)
            {
                if (((IParameterCommand) commandInstance).GetNumberOfParameters() == parameters.Length)
                {
                    ((IParameterCommand) commandInstance).SetParameters(parameters);
                }
                else
                {
                    _outputHandler.AddSyntaxErrorMessage(commandInstance);
                    return null;
                }
            }
            else if (parameters.Length > 0)
            {
                _outputHandler.AddSyntaxErrorMessage(commandInstance);
                return null;
            }

            if (commandInstance is IOperateOnFileSystem)
            {
                ((IOperateOnFileSystem) commandInstance).SetFileSystemHandler(_fileSystemHandler);
            }

            if (commandInstance is IOperateOnView)
            {
                ((IOperateOnView) commandInstance).SetOutputHandler(_outputHandler);
            }

            return commandInstance;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(@$"Error occurred during command creation 
                for acronym '{acronym}': {ex.Message}", ex);
        }
    }
    
    private bool IsCommandAcronymValid(string acronym)
    {
        return AvailableCommands.ContainsKey(acronym);
    }
}