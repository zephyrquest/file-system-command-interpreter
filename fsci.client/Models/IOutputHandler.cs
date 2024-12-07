using fsci.client.Commands;
using Command = fsci.client.Commands.Command;

namespace fsci.client.Models;

public interface IOutputHandler
{
    event Action<string> StateChanged;

    void ClearOutput();
    List<Command> ListAvailableCommands();
    void AddSuccessOperationMessage(IOperationSuccessOutputMessage command);
    void AddUnSuccessOperationMessage(IOperationUnSuccessOutputMessage command);
    void AddSyntaxErrorMessage(Command command);
    void AddCommandNotFoundMessage(string acronym);
    void NotifyStateChange();
}