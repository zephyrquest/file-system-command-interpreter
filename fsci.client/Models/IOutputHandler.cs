using fsci.client.Commands;
using Command = fsci.client.Commands.Command;

namespace fsci.client.Models;

public interface IOutputHandler
{
    event Action<string> StateChanged;

    void ClearOutput();
    List<Command> ListAvailableCommands();
    void AddSuccessOperationMessage(IOperationSuccessOutputMessage command, string input);
    void AddUnSuccessOperationMessage(IOperationUnSuccessOutputMessage command, string input);
    void AddSyntaxErrorMessage(Command command, string input);
    void AddCommandNotFoundMessage(string acronym);
    void NotifyStateChange();
}