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

 public override void Execute()
 {
  if (_outputHandler == null)
  {
   throw new InvalidOperationException("Output Handler has not been set.");
  }
  
  _outputHandler.ClearOutput();
 }

 public override string GetSynopsis()
 {
  return "clear";
 }

 public override string GetDescription()
 {
  return "clear the output area";
 }

 public void SetOutputHandler(IOutputHandler outputHandler)
 {
  _outputHandler = outputHandler;
 }
}