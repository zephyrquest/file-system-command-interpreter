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

    public void ListAvailableCommands()
    {
        throw new NotImplementedException();
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
        _output += $"{command.Acronym}: syntax error (usage {command.GetSynopsis()}).\n";
        
        NotifyStateChange();
    }

    public void AddCommandNotFoundMessage(string acronym)
    {
        _output += $"{acronym}: command not found.\n";
        
        NotifyStateChange();
    }

    public void NotifyStateChange()
    {
        StateChanged?.Invoke(_output);
    }
}