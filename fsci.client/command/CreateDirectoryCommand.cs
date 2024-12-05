namespace fsci.client.command;

/**
 * Class representing the command for creating a directory inside the current working directory
 */
public class CreateDirectoryCommand : Command, IOutputMessage
{
 public CreateDirectoryCommand(string acronym) : base(acronym)
 {
 }

 public override int GetNumberOfArguments()
 {
  return 1;
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
  return $"{userInput}: syntax error (usage: mkdir <dir name>.";
 }
}