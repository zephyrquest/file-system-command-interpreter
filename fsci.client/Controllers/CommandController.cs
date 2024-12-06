using fsci.client.Models;
using fsci.client.view;

namespace fsci.client.Controllers;

public class CommandController
{
    private readonly CommandInputView _commandInputView;
    private readonly OutputAreaView _outputAreaView;

    private readonly CommandManager _commandManager;


    public CommandController(CommandInputView commandInputView, OutputAreaView outputAreaView,
        CommandManager commandManager)
    {
        _commandInputView = commandInputView;
        _outputAreaView = outputAreaView;
        _commandManager = commandManager;

        _commandInputView.InputField.Completed += OnCommandEntered;
    }

    private void OnCommandEntered(object? sender, EventArgs e)
    {
        string commandInput = _commandInputView.InputField.Text;

        if (string.IsNullOrEmpty(commandInput))
        {
            return;
        }
        
        var inputCommandParts = SplitCommandInput(commandInput);

        var commandAcronym = GetCommandAcronym(inputCommandParts);
        var arguments = GetCommandArguments(inputCommandParts);

        if (_commandManager.IsCommandValid(commandAcronym))
        {
            var command = _commandManager.CreateCommand(commandAcronym);
                
            /*if (arguments.Length == command.getGetNumberOfArguments())
            {
                command.Arguments = arguments;
            }
            else
            {
                
            }*/
        }
        else
        {
            
        }
    }

    private string[] SplitCommandInput(string input)
    {
        input = input.Trim();
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private string GetCommandAcronym(string[] input)
    {
        return input[0];
    }

    private string[] GetCommandArguments(string[] input)
    {
        return input.Length > 1 ? input[1..] : Array.Empty<string>();
    }
}