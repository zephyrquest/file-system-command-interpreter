namespace fsci.client.Commands;

/**
 * Class representing the command for printing the full filename of the current working directory
 */
public class PrintCurrentPathCommand : Command, IOutputMessage
{
 public PrintCurrentPathCommand(string acronym) : base(acronym)
 {
 }

 public override int GetNumberOfArguments()
 {
  return 0;
 }

 public override void Execute()
 {
  throw new NotImplementedException();
 }

 public string GetOperationSuccessMessage()
 {
  throw new NotImplementedException();
 }

 public override string GetSyntaxErrorMessage(string userInput)
 {
  return $"{userInput}: syntax error (usage: pwd).";
 }
}