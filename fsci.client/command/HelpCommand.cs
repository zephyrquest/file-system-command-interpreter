namespace fsci.client.command;

/**
 * Class representing the command for listing all available commands and their details
 */
public class HelpCommand : Command
{
 public HelpCommand(string acronym) : base(acronym)
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

 public override string GetSyntaxErrorMessage(string userInput)
 {
  return $"{userInput}: syntax error (usage: help).";
 }
}