using System.Text;
using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for listing all available commands and their details
 */
public class ListAvailableCommandsCommand : Command, IOperateOnView, IOperationSuccessOutputMessage
{
 private IOutputHandler? _outputHandler;

 // output
 private List<Command> _commands;
 
 public ListAvailableCommandsCommand(string acronym) : base(acronym)
 {
 }

 public override void Execute(string input)
 {
  if (_outputHandler == null)
  {
   throw new InvalidOperationException("Output Handler has not been set.");
  }
  
  _commands = _outputHandler.ListAvailableCommands();
  
  _outputHandler.AddSuccessOperationMessage(this, input);
 }

 public override string GetSynopsis()
 {
  return LocalizationHandler.GetInstance().GetValue("command.help.synopsis");
 }

 public override string GetDescription()
 {
  return LocalizationHandler.GetInstance().GetValue("command.help.description");
 }

 public string GetOperationSuccessMessage()
 {
  StringBuilder stringBuilder = new StringBuilder();
  
  foreach (var command in _commands)
  {
   stringBuilder
    .Append(command.Acronym)
    .Append($" ({command.GetDescription()}): ")
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