using System.Reflection;
using fsci.client.Commands;
using Command = fsci.client.Commands.Command;

namespace fsci.client.Models;

public class OutputHandler : IOutputHandler
{
    private string _output = string.Empty;
    

    public event Action<string>? StateChanged;

    
    public void ClearOutput()
    {
        _output = string.Empty;
        
        NotifyStateChange();
    }

    public List<Command> ListAvailableCommands()
    {
        var commands = new List<Command>();
        
        foreach (var availableCommand in CommandManager.AvailableCommands)
        {
            var commandClass = availableCommand.Value;
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(commandClass);
            
            if (type == null)
            {
                throw new TypeLoadException($"Type '{commandClass}' could not be found in the assembly.");
            }
            
            var instance = Activator.CreateInstance(type, availableCommand.Key);

            if (instance is not Command commandInstance)
            {
                throw new InvalidOperationException($"The type '{commandClass}' is not a valid Command.");
            }
            
            commands.Add(commandInstance);
        }

        return commands;
    }

    public void AddSuccessOperationMessage(IOperationSuccessOutputMessage command)
    {
        _output += $"{command.GetOperationSuccessMessage()}\n";
        
        NotifyStateChange();
    }
    
    public void AddUnSuccessOperationMessage(IOperationUnSuccessOutputMessage command)
    {
        _output += $"{command.GetOperationUnSuccessMessage()}\n";
        
        NotifyStateChange();
    }
    
    public void AddSyntaxErrorMessage(Command command)
    {
        _output += string.Format(LocalizationHandler.GetInstance().GetValue("command.syntaxerror"), 
            command.Acronym, command.GetSynopsis()) + "\n";
        
        NotifyStateChange();
    }

    public void AddCommandNotFoundMessage(string acronym)
    {
        _output += string.Format(LocalizationHandler.GetInstance().GetValue("command.notfound"), acronym) + "\n";
        
        NotifyStateChange();
    }

    public void NotifyStateChange()
    {
        StateChanged?.Invoke(_output);
    }
}