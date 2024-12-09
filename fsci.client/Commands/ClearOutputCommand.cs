using fsci.client.Models;

namespace fsci.client.Commands;

/**
 * Class representing the command for clearing the output view
 */
public class ClearOutputCommand : Command, IOperateOnView
{
 private IOutputHandler? _outputHandler;
 
 public ClearOutputCommand(string acronym) : base(acronym)
 {
 }

 public override void Execute(string input)
 {
  if (_outputHandler == null)
  {
   throw new InvalidOperationException("Output Handler has not been set.");
  }
  
  _outputHandler.ClearOutput();
 }

 public override string GetSynopsis()
 {
  return LocalizationHandler.GetInstance().GetValue("command.clear.synopsis");
 }

 public override string GetDescription()
 {
  return LocalizationHandler.GetInstance().GetValue("command.clear.description");
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }
}