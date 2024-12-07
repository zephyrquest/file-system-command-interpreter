using System.Text;
using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for listing all available commands and their details
 */
public class ListAvailableCommandsCommand : Command, IOperateOnView, IOperationSuccessOutputMessage
{
 private IOutputHandler? _outputHandler;

 private List<Command> _commands;
 
 public ListAvailableCommandsCommand(string acronym) : base(acronym)
 {
 }

 public override void Execute()
 {
  if (_outputHandler == null)
  {
   throw new InvalidOperationException("Output Handler has not been set");
  }
  
  _commands = _outputHandler.ListAvailableCommands();
  
  _outputHandler.AddSuccessOperationMessage(this);
 }

 public override string GetSynopsis()
 {
  return "help";
 }

 public override string GetDescription()
 {
  return "list all commands available with their description and synopsis";
 }

 public string GetOperationSuccessMessage()
 {
  StringBuilder stringBuilder = new StringBuilder();
  
  foreach (var command in _commands)
  {
   stringBuilder
    .Append(command.Acronym)
    .Append($" ({command.GetDescription()}) ")
    .Append(command.GetSynopsis())
    .Append("\n");
  }

  return stringBuilder.ToString();
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }
}