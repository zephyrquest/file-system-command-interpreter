using fsci.client.Commands;
using fsci.client.Models;
using fsci.client.view;

namespace fsci.client.Controllers;

public class CommandController
{
    private readonly IInputView _inputView;
    private readonly IOutputView _outputView;

    private readonly IOutputHandler _outputHandler;

    private readonly CommandManager _commandManager;

    
    public CommandController(IInputView inputView, IOutputView outputView, 
        IOutputHandler outputHandler,
        CommandManager commandManager)
    {
        _inputView = inputView;
        _outputView = outputView;

        _outputHandler = outputHandler;

        _commandManager = commandManager;
        
        _inputView.SetEventListener(HandleInput);
        _outputHandler.StateChanged += UpdateOutputView;
    }

    private void HandleInput(string input)
    {
        try
        {
            string commandInput = _inputView.RetrieveInput();

            if (string.IsNullOrEmpty(commandInput))
            {
                return;
            }

            commandInput = commandInput.Trim();

            var inputCommandParts = SplitCommandInput(commandInput);

            var commandAcronym = GetCommandAcronym(inputCommandParts);
            var arguments = GetCommandParameters(inputCommandParts);
            
            var command = _commandManager.CreateCommand(commandAcronym, arguments);

            if (command != null)
            {
                command.Execute();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error during parsing of the command", ex);
        }
        finally
        {
            _inputView.ClearInput();
        }
    }

    private void UpdateOutputView(string output)
    {
        _outputView.SetOutput(output);
    }
    
    private string[] SplitCommandInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private string GetCommandAcronym(string[] input)
    {
        if (input.Length == 0)
        {
            throw new ArgumentException("No command specified");
        }
        
        return input[0];
    }

    private string[] GetCommandParameters(string[] input)
    {
        return input.Length > 1 ? input[1..] : Array.Empty<string>();
    }
}