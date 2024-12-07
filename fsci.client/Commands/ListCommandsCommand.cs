using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for listing all available commands and their details
 */
public class ListCommandsCommand : Command, IOperateOnView, IOperationSuccessOutputMessage
{
 private IOutputHandler? _outputHandler;
 
 public ListCommandsCommand(string acronym) : base(acronym)
 {
 }

 public override void Execute()
 {
  if (_outputHandler == null)
  {
   throw new InvalidOperationException("Output Handler has not been set");
  }
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
  throw new NotImplementedException();
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }
}